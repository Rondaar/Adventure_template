using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Saver : MonoBehaviour {

    public string uniqueIdentifier;
    public SaveData saveData;

    protected string key;

    private SceneController sceneController;

    protected virtual void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
        if (sceneController==null)
        {
            throw new UnityException("Scene Controller could not be found, ensure that it exist in the persistant scene");

        }
        key = SetKey();
    }

    private void OnEnable()
    {
        if (sceneController == null)
        {
            
        }
        sceneController.BeforeSceneUnload += Save;
        sceneController.AfterSceneLoad += Load;
    }

    private void OnDisable()
    {
        sceneController.BeforeSceneUnload -= Save;
        sceneController.AfterSceneLoad -= Load;
    }

    protected abstract string SetKey();

    protected abstract void Save();

    protected abstract void Load();
}
