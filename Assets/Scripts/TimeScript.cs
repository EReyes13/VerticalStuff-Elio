using UnityEngine;
//using TextMeshPro;

public class TimeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Clock = 1;
    public bool day = true;
   // public TextMeshProUGUI TypeShi;

    // Update is called once per frame
    void Update()
    {
        if (day) 
        {
            Clock += Time.deltaTime;
        }
        else
        {
            Clock -= Time.deltaTime;
           if(PlayerMove2.instance != null)
           {
             PlayerMove2.instance.Cooked();
           } 
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
