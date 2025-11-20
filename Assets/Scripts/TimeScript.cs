using UnityEngine;

public class TimeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Clock = 0;
    public bool day;

    // Update is called once per frame
    void Update()
    {
        if (day) {
            Clock += Time.deltaTime;
        }
        else
        {
            Clock -= Time.deltaTime;
        }
        if (Clock >= 300)
        {
            day = false;
        }
        if(Clock<= 0.1)
        {
            day = true;
        }
    }
}
