using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
public class HandleAnimation : MonoBehaviour {
    private UnityArmatureComponent armature;
    private string currAnim;
    // Use this for initialization
    private void Start()
    {
        armature = GetComponentInChildren<UnityArmatureComponent>();
    }
    public void Flip()
    {
        armature.armature.flipX = !armature.armature.flipX;
    }
    public void PlayAnimation(string name,float fadeIn, int howMany)
    {
        if (currAnim!=name)
       {
            
            armature.animation.FadeIn(name, fadeIn, howMany);
            currAnim = name;
       }
    }
}
