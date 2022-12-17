using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject[] _stars;
    
    public void RenderStars(int currentAmountStars)
    {
        for(int i = 0; i <= currentAmountStars - 1; i++)
            _stars[i].SetActive(true);
    }
}