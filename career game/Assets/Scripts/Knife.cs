using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Cuttable cuttable = collision.gameObject.GetComponent<Cuttable>();

        if (cuttable != null)
        {
            cuttable.Hit();
        }
    }
}