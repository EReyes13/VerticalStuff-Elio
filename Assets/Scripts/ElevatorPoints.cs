using UnityEngine;

public class ElevatorPoints : MonoBehaviour
{
    public bool Activated;
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }
}
