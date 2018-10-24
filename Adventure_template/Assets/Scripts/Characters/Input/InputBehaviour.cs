using System;
using UnityEngine;

public abstract class InputBehaviour : MonoBehaviour {

	public float Horizontal { get; protected set; }
    public float Vertical { get; protected set; }
    public bool ActionA { get; protected set; }
    public bool ActionB { get; protected set; }

    public event Action OnActionA = delegate { };
    public event Action OnActionB = delegate { };

    protected void CheckForEvents()
    {
        if (ActionA) OnActionA();
        if (ActionB) OnActionB();
    }
}
