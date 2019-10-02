using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;

    // Update is called once per frame
    void Update()
    {
        // let the laser go to de top
        transform.Translate(_speed * Time.deltaTime * Vector3.up);
        
        //if laser y position greater than 8, destroy it
        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }
}
