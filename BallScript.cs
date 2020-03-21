using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform Explosion;
    public Transform powerup;
    public GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        
    }

    // Update is called once per frame
    // pallon laukaisu välilyönnillä
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        if (!inPlay)
        {
            transform.position = paddle.position;
        }
        if (Input.GetButtonDown ("Jump")&& !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed );


        }
    }

    // pallo palaa padille osuttuaan pohjaan
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other. CompareTag("Bottom"))
        {
           // Debug.Log("Ball hit the Bottom");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }

    // tiilien tuhoutuminen ja roiskeet, roiskeet pois herarkiasta
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick"))
        {
            BrickScript brickSscipt = other.gameObject.GetComponent<BrickScript>();
            if (brickSscipt.hitsToBrake > 1)
            {
                brickSscipt.BreakeBrick();
            }
            else
            {
                //powerup scale
                int randChange = Random.Range(1, 101);
                if (randChange < 30)
                {
                    Instantiate(powerup, other.transform.position, other.transform.rotation);
                }


                Transform newExplosion = Instantiate(Explosion, other.transform.position, other.transform.rotation);
                Destroy(newExplosion.gameObject, 2.5f);

                gm.UpdateScore(brickSscipt.points);
                gm.UpDateNumberOfBricks();

                Destroy(other.gameObject);
            }
        }




    }

}
