using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePickupScript : BasePickup
{
    public override void Collect()
    {

        GameManager.Instance.TotalSegments++;
        FindObjectOfType<PlayerMovement>().AddSegment();
        Destroy(gameObject);

    }
}
