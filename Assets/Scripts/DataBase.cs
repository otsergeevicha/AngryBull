using System;
using System.Collections.Generic;

[Serializable]
public class DataBase
{
    public List<LevelData> LevelDatas = new List<LevelData>();

    public void Add(int scene, int stars)
    {
        foreach (var data in LevelDatas)
        {
            if (data.Scene == scene)
            {
                data.Stars = stars;
                return;
            }
        }

        LevelDatas.Add(new LevelData(scene, stars));
    }

    public int Read(int scene)
    {
        foreach (var data in LevelDatas)
        {
            if (data.Scene == scene)
            {
                return data.Stars;
            }
        }

        return 0;
    }
}