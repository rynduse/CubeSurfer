using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    private Character player;
    public Character Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }
    public void AddCharacter(Character character)
    {
        Player = character;
    }

    public void RemoveCharacter(Character character)
    {
        Player = null;
    }
}