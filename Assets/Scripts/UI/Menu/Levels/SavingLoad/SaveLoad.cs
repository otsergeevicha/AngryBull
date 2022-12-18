using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private const string StarKey = "StarKey";

    private DataBase _dataBase;

    private void OnEnable()
    {
        _dataBase = PlayerPrefs.HasKey(StarKey)
            ? JsonUtility.FromJson<DataBase>(PlayerPrefs.GetString(StarKey))
            : new DataBase();
    }

    private void OnDisable()
    {
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetString(StarKey, JsonUtility.ToJson(_dataBase));
        PlayerPrefs.Save();
    }

    public void SaveStarsData(int currentScene, int amountStar)
    {
        if(_dataBase.Read(currentScene) < amountStar)
            _dataBase.Add(currentScene, amountStar);

        Save();
    }

    public int ReadStarData(int indexScene)
        => _dataBase.Read(indexScene);

    [ContextMenu("ClearPlayerPrefs")]
    private void ClearPlayerPrefs()
        => PlayerPrefs.DeleteAll();
}