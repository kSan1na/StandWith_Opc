using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    [SerializeField] private Rigidbody _stand;
    public void MakeJoint()
    {
        gameObject.AddComponent<FixedJoint>();
        GetComponent<FixedJoint>().connectedBody = _stand;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
    public void BrakeJoint()
    {
        Destroy(gameObject.GetComponent<FixedJoint>());
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
