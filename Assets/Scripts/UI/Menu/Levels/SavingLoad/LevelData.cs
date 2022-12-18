using System;

[Serializable]
public class LevelData
{
    public int Scene;
    public int Stars;

    public LevelData(int scene, int stars)
    {
        Scene = scene;
        Stars = stars;
    }
}