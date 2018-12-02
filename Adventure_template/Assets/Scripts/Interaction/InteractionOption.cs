using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionOption : ScriptableObject{

    [SerializeField]
    private Sprite icon;

    public Sprite Icon { get { return icon; } private set { } }
    public GameObject MyGO { get; set; }

    public abstract void Interact();
}
