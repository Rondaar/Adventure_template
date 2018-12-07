using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SI_Attack : MonoBehaviour {

    [SerializeField]
    int damage;

    [SerializeField]
    double rateOfFire;

    public Shoot() {
        LaunchProjectile();
    }
}
