using UnityEngine;

public class ElevatorPoints : MonoBehaviour
{
    public Vector3 Check;
    public bool Activated;
    void Start()
    {
        Check = gameObject.transform.position;
    }

    // Update is called once per frame
    public static ElevatorPoints instance {get; private set;}

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
    void Update()
    {
        
    }

    public void OnTriggerEnter2D (Collider2D other)
    {
        if(Activated == false)
        {
            if(ElevatorScript.instance != null)
            {
                ElevatorScript.instance.Checkpoint = gameObject.transform.position;
            }
            Activated = true;
        }
        else
        {
            if(other.gameObject.CompareTag("Player"))
        {
           other.gameObject.transform.position = Check;
        }
        }
    }
}
