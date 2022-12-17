using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SaveLoad _saveLoad;

    public int CurrentScene => SceneManager.GetActiveScene().buildIndex;
    
    public void SelectLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}