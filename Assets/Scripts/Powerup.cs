using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    //[SerializeField]
    //private float _speed = (3f);

    [SerializeField]
    float _randomSpeed;
    [SerializeField] //0 = TripleShot, 1 = Speed, 2 = Shields
    private int powerupID;
    

    
    // Start is called before the first frame update
    void Start()
    {
        _randomSpeed = Random.Range(2f, 5f); ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _randomSpeed * Time.deltaTime);
        
        if (transform.position.y < -9.0f)
        {
            Destroy(this.gameObject);
        }

        //move down at a speed of 3 (adjust in inspector
        //when we leave the screen, destroy this object
    }

            
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

        Player player = other.transform.GetComponent<Player>();
        if (player != null)
        {
             switch(powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        break;
                    case 3:
                        Debug.Log("Default Value");
                        break;
                }
        }
            Destroy(this.gameObject);
        }

   // public enum PowerUpType
    //{
    //    TripleShot,
    //    SpeedBoost,
    //    Shield
    //}

    

    //public class PowerUp
    //{
       // public PowerUpType type; //This stores the type of power-up

       // public PowerUp(PowerUpType type)
       // { 
       //     this.type = type; 
       // }

   // public void Activate()
       // {
            // Here, you can decide what happens when the power-up is used.
            // For example, if it's a Speed Boost:
        //    PowerUp speeBoostPowerUp = new PowerUp(PowerUpType.SpeedBoost);
        //    PowerUp tripleShotPowerUp = new PowerUp(PowerUpType.TripleShot);
         //   PowerUp shieldPowerUp = new PowerUp(PowerUpType.Shield);

         //   if (type == PowerUpType.TripleShot)
         //   {
         //       tripleShotPowerUp.type = PowerUpType.TripleShot;
         //       tripleShotPowerUp.Activate();
         //   }

         //   else if (type == PowerUpType.SpeedBoost)
          //  {
          //      speeBoostPowerUp.type = PowerUpType.SpeedBoost;
          //      speeBoostPowerUp.Activate();
          //  }

            //else if (type == PowerUpType.Shield)
            //{
              //  shieldPowerUp.type = PowerUpType.Shield;
              //  shieldPowerUp.Activate();
            //}
        }
    }

