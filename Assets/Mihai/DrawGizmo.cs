using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{   

    void OnDrawGizmos()
    {

        Gizmos.color = transform.parent.GetComponent<SpriteRenderer>().color;
        
        Gizmos.DrawWireCube(transform.position,transform.localScale);
    }

}
