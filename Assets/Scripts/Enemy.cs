using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 7, 0);   
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -7f)
        {
            transform.position = new Vector3(Random.Range(-9.45f, 9.45f), 7, 0);
        }
        
        transform.Translate(_speed * Time.deltaTime * Vector3.down);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);    
        }


        if (other.transform.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
