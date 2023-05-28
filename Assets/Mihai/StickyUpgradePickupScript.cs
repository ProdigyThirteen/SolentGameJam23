using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyUpgradePickupScript : BasePickup
{
    public override void Collect()
    {
        GameManager.Instance.StickyAcquired = true;
        Destroy(gameObject);
    }
}
