using System;
using System.Collections;
using UnityEngine;

public class delete : MonoBehaviour
{
    [SerializeField] private float time;

    private void Start()
    {
        StartCoroutine(del());
    }

    IEnumerator del()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
