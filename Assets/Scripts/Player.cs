using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _fireFate = 0.5f;

    private float _canFire = -1f;
    
    // Start is called before the first frame update
    void Start()
    {
        //take the current position and then set to Vector3(0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
       CalculateMovement();
       
       //if hit space key, spawn GameObject(prefab)

       if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
       {
           FireLaser();
       }
    }

    private void FireLaser()
    {
        _canFire = Time.time + _fireFate;
           
        var offsetStartLaserPosition = transform.position + new Vector3(0, 0.8f, 0); 
           
        Instantiate(_laserPrefab, offsetStartLaserPosition, Quaternion.identity);
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(horizontalInput * _speed * Time.deltaTime * Vector3.right);
        transform.Translate(verticalInput * _speed * Time.deltaTime * Vector3.up);

        //Mathf.Clamp
        
        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, transform.position.z);
        }
        
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        else if (transform.position.y <= -4)
        {
            transform.position = new Vector3(transform.position.x, -4, transform.position.z);
        }
    }
}