using UnityEngine;

public class DecPlatform : MonoBehaviour
{
    public float Countdown = 5;
    public float cooldown = 5;
    public bool decay;
    public float Alpha = 1;
    public SpriteRenderer SR;

    public BoxCollider2D box;

    // Update is called once per frame
        void Update()
    {
        if (decay)
        {
            Countdown -= Time.deltaTime;
            SR.color = new Color(0.6f,0.4f,0.2f,Alpha);
            Alpha -= (0.2f*Time.deltaTime);
        }
        if (Countdown <= 0)
        {
            //Destroy(gameObject);
            box.enabled = false;
            decay = false;
            cooldown -= Time.deltaTime;
        }
        if(cooldown <= 0.01f)
        {
            box.enabled = true;
            Countdown = 5;
            cooldown = 5;
            SR.color = new Color(0.6f,0.4f,0.2f,1);
            Alpha = 1;
        } 
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            decay = true;
        }
    }
}
