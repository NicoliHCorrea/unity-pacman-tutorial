using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "")]


public class PlayerInfo : ScriptableObject
{
    public string player_name;
    public int age;
    public string gender;

    public void changeName(string str)
    {
        player_name = str;
    }

    public string getName()
    {
        return player_name;
    }

    public void changeAge(int num)
    {
        age = num;
    }

    public int getAge()
    {
        return age;
    }

    public void changeGender(string str)
    {
        gender = str;
    }

    public string getGender()
    {
        return gender;
    }
}
