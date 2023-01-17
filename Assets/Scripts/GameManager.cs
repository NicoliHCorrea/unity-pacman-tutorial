using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;



public class GameManager : MonoBehaviour
{   
    private CancellationTokenSource powerPelletSoundCts;

    public BGSound scriptSound;

    public AudioSource BGsound;
    public AudioSource PelletSound;
    public AudioSource DeathSound;
    public AudioSource GhostEatenSound;

    public AudioClip[] clips;
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;

    public bool playWaka1 = true;
    public bool superPellet = false;

    public Text gameOverText;
    public Text scoreText;
    public Text livesText;

    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.anyKeyDown) {
            NewGame();
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        gameOverText.enabled = false;

        foreach (Transform pellet in pellets) {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        for (int i = 0; i < ghosts.Length; i++) {
            ghosts[i].ResetState();
        }

        pacman.ResetState();
        BGsound.Play();

    }

    private void GameOver()
    {
        gameOverText.enabled = true;

        for (int i = 0; i < ghosts.Length; i++) {
            ghosts[i].gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
        LogFile.instance.allText.Add("Número de inputs: " + pacman.inputs.ToString());
        LogFile.instance.allText.Add("Pontuação alcançada: "+score.ToString());
        LogFile.instance.endGame();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = "x" + lives.ToString();
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString().PadLeft(2, '0');
    }

    public void PacmanEaten()
    {
        pacman.DeathSequence();
        BGsound.Stop();
        DeathSound.Play();
        SetLives(lives - 1);

        if (lives > 0) {
            Invoke(nameof(ResetState), 3f);
        } else {
            GameOver();
        }
    }

    public void GhostEaten(Ghost ghost)
    {
        GhostEatenSound.Play();
        int points = ghost.points * ghostMultiplier;
        SetScore(score + points);

        ghostMultiplier++;
    }

    public void PelletEaten(Pellet pellet)
    {   
        pellet.gameObject.SetActive(false);

        if (playWaka1 == true){
            PelletSound.clip = clips[0];
            playWaka1 = false;
        }
        else{
            PelletSound.clip = clips[1];
            playWaka1 = true;
        } 
        PelletSound.Play();

        SetScore(score + pellet.points);

        if (!HasRemainingPellets())
        {
            pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3f);
        }
        
    }

    public async void PowerPelletEaten(PowerPellet pellet)
{
    for (int i = 0; i < ghosts.Length; i++) {
        ghosts[i].frightened.Enable(pellet.duration);
    }

    superPellet = true;
    PelletEaten(pellet);
    
    BGsound.clip = clips[2];
    BGsound.Play();
    
    CancelInvoke(nameof(ResetGhostMultiplier));
    Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    
    powerPelletSoundCts?.Cancel();
    powerPelletSoundCts = new CancellationTokenSource();
    scriptSound.PelletReset(pellet.duration, powerPelletSoundCts.Token);
}


    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in pellets)
        {
            if (pellet.gameObject.activeSelf) {
                return true;
            }
        }

        return false;
    }

    private void ResetGhostMultiplier()
    {
        ghostMultiplier = 1;
    }

}
