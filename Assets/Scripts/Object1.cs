using UnityEngine;

public class Object1 : MonoBehaviour
{
    public BoxCollider2D BC;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
          if(PlayerMove2.instance != null)
          {
            PlayerMove2.instance.PermaEffect();
          }
          TimeScript.Ticking = false;
           Destroy(gameObject);
        }
    }
}
