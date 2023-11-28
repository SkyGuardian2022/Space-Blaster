using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _randomSpeed;

    [SerializeField]
    private Player _player;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _randomSpeed = Random.Range(3f, 8f);

        _player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _randomSpeed * Time.deltaTime);

        if(transform.position.y < -7f)
        {
            float randomX = Random.Range(-9, 9);
           transform.position = new Vector3(randomX, 7, 0);
        }

    }
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null )
            {
                player.Damage();
            }
            
            Destroy(this.gameObject);
        }

        if(other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore();
            }
            Destroy(this.gameObject);
        }
    }


}
