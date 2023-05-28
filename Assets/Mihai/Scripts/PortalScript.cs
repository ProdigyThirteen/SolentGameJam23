using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject resetPosition;
    private GameObject player;

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.W))
        {

            if (player != null)
            {

                if (!player.GetComponent<PlayerMovement>().IsExtending())
                    player.transform.position = resetPosition.transform.position;

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("col enter");
        player = checkPlayerOverlap();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        Debug.Log("col exit");
        player = null;

    }

    GameObject checkPlayerOverlap()
    {

        Collider2D coll = GetComponent<BoxCollider2D>();
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        List<Collider2D> results = new List<Collider2D>();

        if (Physics2D.OverlapCollider(coll, filter, results) > 0)
        {
            foreach (Collider2D col in results)
            {

                if(col.gameObject.GetComponent<PlayerMovement>() != null)
                {
                    return col.gameObject;
                }

            }

            return null;
        }

        else
            return null;

    }
}
