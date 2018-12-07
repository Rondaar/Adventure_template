using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToughtsAlign : MonoBehaviour {
    [SerializeField]
    private float range = 2f;
    
    public void AlignToughts()
    {
        GameObject[] toughts =GameObject.FindGameObjectsWithTag("Tought");
        float currAngle = 0;
        float angleChange = 360 / toughts.Length;
        foreach (GameObject tought in toughts)
        {

            tought.GetComponent<Button>().transform.position = Camera.main.WorldToScreenPoint(transform.parent.parent.position);//+Quaternion.Euler(0, 0, currAngle) * Vector2.up * range;
            
            currAngle += angleChange;

        }
    }

}
