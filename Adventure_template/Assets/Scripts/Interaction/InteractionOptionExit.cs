using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Exit Interaction Option", menuName = "Interaction Exit")]
public class Interaction : InteractionOption
{
    [SerializeField]
    string sceneName;

    public override void Interact()
    {
        ChangeScene(sceneName);
    }

    private void ChangeScene(string scene)
    {
        FindObjectOfType<SceneController>().FadeAndLoadScene(scene);
    }
}
