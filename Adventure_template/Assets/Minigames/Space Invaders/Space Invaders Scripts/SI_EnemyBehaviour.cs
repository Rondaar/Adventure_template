using SI_Health;
using SI_Attack;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SI_EnemyBehaviour : SI_ShipsBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move()
    {

    }

    public override void Attack()
    {
        Shoot();
    }

    public override void Die()
    {

    }
}
