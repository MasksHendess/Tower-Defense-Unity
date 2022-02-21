using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTracker : MonoBehaviour
{
    #region LifeManager setup Singelton pattern
    // only 1 instance of BuildManager in scene that is easy to acsess
    // Dont duplicate this region 
    public static LifeTracker instance; //self reference
    private void Awake()
    {
        //check if instance already exisist
        if (instance != null)
        {
            Debug.LogError("More than one LifeTracker in scene");
            return;
        }

        instance = this;
    }
    #endregion 
    public int life = 10; 
    public Text lifeCountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeCountText.text = "Lives: " +life.ToString();
    }

    public void loseLife(int Life)
    {
        life = life - Life;
        if(life <= 0)
        {
            Debug.Log("GAME OVER YOU LOSE");
            Time.timeScale = 0;
        }
    }

    public void gainLife(int Life)
    {
        life = life + Life;
    }

}
