using UnityEngine;

public class DecPlatform : MonoBehaviour
{
    public float Countdown = 5;
    public float cooldown = 5;
    public bool decay;

    public BoxCollider2D box;

    // Update is called once per frame
        void Update()
    {
        if (decay)
        {
            Countdown -= Time.deltaTime;
            
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
