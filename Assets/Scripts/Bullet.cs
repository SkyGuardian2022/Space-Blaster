using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //speed variable of 8
    [SerializeField]
    private float _speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if (transform.position.y >= 7.5f)
        {
            if (transform.parent != null)
            { 
                Destroy(transform.parent.gameObject);
            }

            Destroy(this.gameObject);
        }
        
    }
}
