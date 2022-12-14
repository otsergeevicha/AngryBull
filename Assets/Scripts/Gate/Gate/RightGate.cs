using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RightGate : Gates
{
    [SerializeField] private Player _player;

    private float _range;
    private float positionGate = 0;
    
    private void Update()
    {
        ChangePosition();
    }

    public override void JobGate(float positionY)
    {
        transform.DORotate(new Vector3(0, positionY), 1f);
    }

    private void ChangePosition()
    {
        _range = Vector3.Distance(transform.position, _player.transform.position);
        
        if(_range < 5)
            JobGate(0);

        else
            JobGate(80);
    }
}
