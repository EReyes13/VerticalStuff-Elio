using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SpriteRenderer SR;
    public Rigidbody2D RB;

    public bool Floored;

    public float Speed = 5;
    public float JumpPower = 10;
    public float Gravity = 3;

    public bool moving;

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = RB.linearVelocity;

        if (moving)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {

                vel.x = Speed;



            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {

                vel.x = -Speed;



            }
            else
            {
                vel.x = 0;
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Floored)
                {
                    vel.y = JumpPower;
                }
            }
        }
        RB.linearVelocity = vel;
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.CompareTag("Ledge"))
        {
            moving = false;
            Floored = false;
            RB.linearVelocityY = (-5f);
        }
       
       

        if (other.gameObject.CompareTag("Ice"))
        {
            moving = false;
            RB.linearVelocityY = (-5f);

        }
        /*if (other.gameObject.CompareTag("Floor"))
        {
            moving = true;
            Floored = true;
        }*/
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        Floored = false;
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            moving = true;
            Floored = true;
         }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
      
    }
}
