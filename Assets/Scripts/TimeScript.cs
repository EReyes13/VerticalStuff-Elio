using UnityEngine;
//using TextMeshPro;

public class TimeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Clock = 1;
    public bool day = true;
    public bool noeffect = true;
    public static bool Ticking = true;
   // public TextMeshProUGUI TypeShi;
   public static TimeScript instance {get; private set;}

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
        
        if(Ticking){
        if (day) 
        {
            Clock += Time.deltaTime;
        }
        else
        {
            Clock -= Time.deltaTime;
          
        }
        if(noeffect){
        if (Clock >= 180)
        {
            day = false;
             if(PlayerMove2.instance != null)
           {
             PlayerMove2.instance.Wheel();
           } 
        }}
        else{
         if (Clock >= 60)
        {
            day = false;
             if(PlayerMove2.instance != null)
           {
             PlayerMove2.instance.Wheel();
           } 
        }   
        }
        if(Clock<= 0.1)
        {
            day = true;
        }
        }
    }
    public void StopTime(){
        Ticking = false;
    }
}
