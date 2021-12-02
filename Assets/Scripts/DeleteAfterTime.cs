using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour
{
   [SerializeField] float deleteTime = 10f;
    void Start()
    {
        StartCoroutine(AutoDelete());
    }
    IEnumerator AutoDelete()
    {
        yield return new WaitForSeconds(deleteTime);
        Destroy(gameObject);
    }
}
