using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public void Dissipate()
    {
        // Shrink over time and destroy self
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(Shrink());
    }

    private IEnumerator Shrink()
    {
        // Shrink over time
        while (transform.localScale.x > 0)
        {
            transform.localScale -= Vector3.one * Time.deltaTime * 10;
            yield return null;
        }

        // Destroy self
        Destroy(gameObject);
    }
}
