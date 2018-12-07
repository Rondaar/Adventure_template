using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SI_Health {

    [SerializeField]
    int health;

    public void addXHealth(int healthToAdd)
    {
        health += healthToAdd;
    }

    public void subXHealth(int healthToSub)
    {
        health -= healthToSub;
    }

}
