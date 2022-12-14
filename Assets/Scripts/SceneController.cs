using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneController : MonoBehaviour
{
    public event Action<int> ChangedScene;

    public void SelectLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        ChangedScene?.Invoke(sceneNumber);
    }
}