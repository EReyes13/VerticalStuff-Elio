using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    
    public Vector3 Checkpoint;
    public static ElevatorScript instance {get; private set;}

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

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
           other.gameObject.transform.position = Checkpoint;
        }

    }
}
