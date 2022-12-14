using System;
using UnityEngine;

public class TriggerBeacon : MonoBehaviour
{
    public event Action Entered;
    public event Action Leaving;

    private void OnTriggerEnter(Collider collision)
    {
        if(!collision.TryGetComponent(out Player _))
            return;
        
        Entered?.Invoke();
    }
    
    private void OnTriggerExit(Collider collision)
    {
        if(!collision.TryGetComponent(out Player _))
            return;
        
        Leaving?.Invoke();
    }
}
