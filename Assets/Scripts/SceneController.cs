using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private VerificationAccess _verificationAccess;
    
    public int CurrentScene => SceneManager.GetActiveScene().buildIndex;
    
    public void SelectLevel(int sceneNumber)
    {
        switch(sceneNumber)
        {
            case 0:
                SceneManager.LoadScene(sceneNumber);
                break;
            case 1 when CurrentScene == 0 && _verificationAccess.Verification():
                SceneManager.LoadScene(sceneNumber);
                break;
        }
    }
}