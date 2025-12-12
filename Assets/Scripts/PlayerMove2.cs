using UnityEngine;
using UnityEngine.UI;

public class PlayerMove2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SpriteRenderer SR;
    public Rigidbody2D RB;

    public bool Floored;

    public float Speed = 10;
    public float JumpPower = 15;
    public float Gravity = 3;

    public bool moving;
    
    public int ran;
    public static PlayerMove2 instance {get; private set;}

    public bool Checkpointed;

    public bool Tweaking;
    public bool normal = true;

    public float CookedTime = 30;
    public int TweakID;
    public static int Mult = 1;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = RB.linearVelocity;

        if (moving)
        {
            if(normal){
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {

                vel.x = Speed;



            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
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
             else
             {
                // Inverted controls logic
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {

                    vel.x = -Speed;

                }
                else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {

                    vel.x = Speed;

                }
                else
                {
                    vel.x = 0;
                }
             }
        RB.linearVelocity = vel;
        }
             if (Checkpointed && Input.GetKeyDown(KeyCode.C))
             {
                 if(ElevatorScript.instance != null)
             {
                ElevatorScript.instance.Checkpoint = gameObject.transform.position;
                }
                if(ElevatorPoints.instance != null)
                {
                    ElevatorPoints.instance.Check = gameObject.transform.position;
                }
             Checkpointed = false;
            }
                if(Tweaking)
                {
                CookedTime -= Time.deltaTime;
                if(CookedTime <= 0)
             {
                Tweaking = false;
                CookedTime = 30;
                switch(TweakID)
                {
                    case 0:
                         Speed = 10;
                        break;
                    case 1:
                         JumpPower = 15;
                        break;
                    case 2:
                         Speed = 10;
                        break;
                    case 3:
                         Speed = 15;
                        break;
                    case 4:
                         Checkpointed = false;
                        break;
                    case 5:
                         normal = true;
                        break;
                        default:break;
                }
                
             }
                }
        
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
        moving = true;
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


    public void Wheel()
    {
        Tweaking = true;
         ran = Random.Range(0, 5);
         switch (ran)
         {
             case 0:
                  Boost();
                 break;
             case 1:
                  Jump();
                 break;
             case 2:
                  Cripple();
                 break;
             case 3:
                  Slow();
                 break;
             case 4:
                  Checkpoint();
                 break;
             case 5:
                  Invert();
                 break;
                 default:break;
         }
    }
    public void Boost()
    {
        if(TextScript.instance != null)
        {
            TextScript.instance.EffectID = 0;
            TextScript.instance.ShowEffect();
        }
        TweakID = 0;
        Speed += 5*Mult;
        Debug.Log("Boosted");
    }
    public void Jump()
    {
        if(TextScript.instance != null)
        {
            TextScript.instance.EffectID = 1;
            TextScript.instance.ShowEffect();
        }
        TweakID = 1;
        JumpPower += 5*Mult;
        Debug.Log("Jumped");
    }
    public void Cripple()
    {
        if(TextScript.instance != null)
        {
            TextScript.instance.EffectID = 2;
            TextScript.instance.ShowEffect();
        }
        TweakID = 2;
        JumpPower -= 5*Mult;
        Debug.Log("Crippled");
    }
    public void Slow()
    {
        if(TextScript.instance != null)
        {
            TextScript.instance.EffectID = 3;
            TextScript.instance.ShowEffect();
        }
        TweakID = 3;
        Speed -= 3*Mult;
        Debug.Log("Slowed");
    }
    public void Checkpoint()
    {
        if(TextScript.instance != null)
        {
            TextScript.instance.EffectID = 4;
            TextScript.instance.ShowEffect();
        }
        TweakID = 4;
        Checkpointed = true;
        Debug.Log("Checkpointed");
    }
    public void Invert()
    {
        if(TextScript.instance != null)
        {
            TextScript.instance.EffectID = 5;
            TextScript.instance.ShowEffect();
        }
        TweakID = 5;
        normal = false;
        Debug.Log("Inverted");
    }

    public void PermaEffect()
    {
        
        Speed = 12;
        JumpPower = 17;
    }
}