using UnityEngine;

public class Source : LogicGate
{
    [SerializeField] private bool state;
    
    public override bool Evaluate()
    {
        return state;   
    }
}
