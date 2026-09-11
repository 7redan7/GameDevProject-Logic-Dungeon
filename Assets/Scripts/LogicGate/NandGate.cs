using UnityEngine;
using System.Collections.Generic;

public class NandGate : LogicGate
{
    public override bool Evaluate()
    {
        List<Vector3> inputs = this.GetSideType(SideType.Input);

        for (int i = 0; i < inputs.Count; i++)
        {
            Collider2D col = Physics2D.OverlapPoint(this.transform.position + inputs[i]);
            if (col != null && col.TryGetComponent<LogicGate>(out LogicGate other))
            {
                List<Vector3> other_outputs = other.GetSideType(SideType.Output);
                if (other_outputs.Contains(inputs[i] * -1))
                {
                    if (!other.Evaluate())
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }
        }
        return false;
    }
}