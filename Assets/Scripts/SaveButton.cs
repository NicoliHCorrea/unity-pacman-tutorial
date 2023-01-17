using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class SaveButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private TMP_InputField inputAge;
    [SerializeField] private TMP_InputField inputGender;

    [SerializeField] private PlayerInfo scriptable;

    private int age;
    
    public void save()
    {
        scriptable.changeName(inputName.text);
        age = Int32.Parse(inputAge.text);
        scriptable.changeAge(age);
        scriptable.changeGender(inputGender.text);
    }

}
