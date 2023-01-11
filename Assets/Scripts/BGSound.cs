using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;
using System.Threading.Tasks;

public class BGSound : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource bgs;
    [SerializeField] public MusicName scriptable; 

    void Start()
    {   
        ResetBG();
    }

    public void ResetBG()
    {   
        if (scriptable.getMusic() == "Normal"){
            bgs.clip = clips[0];
        }
        else if (scriptable.getMusic() == "Alternativa"){
            bgs.clip = clips[1];
        }
        bgs.Play();

    }

    public async void PelletReset(float delay, CancellationToken ct)
{   
    int delayi = (int)delay;
    try{
        await Task.Delay(delayi * 1000, ct); // o tempo aqui é em milisegundos
    }
    catch{return;}

    ResetBG();
}

}
