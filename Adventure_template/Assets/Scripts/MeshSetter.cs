using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MeshSetter : MonoBehaviour {

    public GameObject[] meshes;
    public GameObject parent;
    public Transform meshPar;

    // Use this for initialization


    private void OnValidate()
    {
        parent = gameObject;
        foreach(GameObject mesh in meshes)
        {
            Transform newChild = parent.transform.Find(mesh.name);
            Vector3 newPos = newChild.localPosition;
            DestroyImmediate(newChild);
            mesh.transform.SetParent(parent.transform);
            mesh.transform.localPosition = newPos;
            mesh.transform.SetParent(meshPar);


        }
    }
}
