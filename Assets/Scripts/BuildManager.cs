using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    #region Buildmanager setup Singelton pattern
    // only 1 instance of BuildManager in scene that is easy to acsess
    // Dont duplicate this region 
    public static BuildManager instance; //self reference
    private void Awake()
    {
        //check if instance already exisist
        if(instance!= null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }

        instance = this;
    }
    #endregion 
    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab;
    private GameObject turretToBuild;

    public int playerCash;
    public Text playerCashText;
    // Start is called before the first frame update
    //void Start()
    //{
    //    turretToBuild = standardTurretPrefab;
    //}

    // Update is called once per frame
    void Update()
    {
       playerCashText.text = "Cash: " + playerCash.ToString();
    }

    public void SetTurretToBuild(GameObject turret, int cost)
    {
        if(playerCash >= cost)
        { 
            turretToBuild = turret;
        }
        else
        {
            turretToBuild = null;
        }
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public bool payForTurretToBuild(int cost)
    {
        Debug.Log(playerCash);
        if (playerCash >= cost)
        {
            playerCash -= cost;
            return true;
        }
        else
            return false;
    }

}
