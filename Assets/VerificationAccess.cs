using UnityEngine;

public class VerificationAccess : MonoBehaviour
{
    [SerializeField] private GameObject _iconLockedLocal;
    [SerializeField] private SaveLoad _saveLoad;
    [SerializeField] private SceneController _sceneController;

    private void Start()
    {
        Verification();
    }

    public bool Verification()
    {
        if(_saveLoad.ReadStarData(_sceneController.CurrentScene) < 4) return false;
        _iconLockedLocal.gameObject.SetActive(false);
        return true;
    }
}