using UnityEngine;
using UnityEngine.UIElements;

public class Object2 : MonoBehaviour
{
    public BoxCollider2D Boxystuff;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
          PlayerMove2.Mult ++;
          if(TimeScript.instance != null)
            {
                TimeScript.instance.noeffect = false;
                TimeScript.instance.Clock = 0;
            }
           Destroy(gameObject);
        }
    }
}
