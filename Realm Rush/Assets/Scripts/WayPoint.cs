using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPalceable;
    [SerializeField] GameObject ballista;

    public bool IsPalceable { get => isPalceable; set => isPalceable = value; }
    private void OnMouseDown()
    {
        if (isPalceable)
        {
            Debug.Log(transform.name);
            Instantiate(ballista, transform.position,Quaternion.identity);
            isPalceable = false;
        }
        
    }
}
