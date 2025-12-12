using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public TextMeshProUGUI EffectText;
    public int EffectID = 5;
    public float EffectDuration = 5f;
    public bool EffectActive = false;
    public static TextScript instance {get; private set;}

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
        EffectText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(EffectActive)
        {
            EffectDuration -= Time.deltaTime;
            if(EffectDuration <= 0)
            {
                EffectActive = false;
                EffectText.gameObject.SetActive(false);
                EffectDuration = 5f;
            }
        }
    }
    public void ShowEffect()
    {
        EffectActive = true;
        EffectText.gameObject.SetActive(true);
        switch(EffectID)
        {
            case 0:
            if(PlayerMove2.Mult == 2)
                {
                    EffectText.text = "Even Faster! Gambling is fun!";
                    break;
                }
                else
                {
                    EffectText.text = "Boost! Increased Speed!";
                }
            break;
           
            case 1:
            if(PlayerMove2.Mult == 2)
                {
                    EffectText.text = "Super Jump! Gambling pays off!";
                    break;
                }
            else
                {
                    EffectText.text = "Jumped! Increased Jump Power!";
                }
            break;
           
            case 2:
            if(PlayerMove2.Mult == 2)
                {
                    EffectText.text = "Severely Crippled! Oof!";
                    break;
                }
            else
                {
                    EffectText.text = "Crippled :( That's tuff twin)";
                }
            break;
            
            case 3:
           if(PlayerMove2.Mult == 2)
                {
                    EffectText.text = "Extremely Slowed!That's on you bud.";
                    break;
                }
            else
                {
                    EffectText.text = "Slowed! Get better lmao";
                    
                }
                break;
            
            case 4:
            EffectText.text = "Checkpoint Reached! Press E to respawn here upon interacting with an elevator.";
            break;
            case 5:
            EffectText.text = "Inverted Controls! Ur cooked twin.";
            break;
            default:break;
        }
    }
}
