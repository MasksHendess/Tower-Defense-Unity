using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;
    private Turret turret;
        // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region ShopItems
    public void BuyStandardTurret()
    {
        turret = buildManager.standardTurretPrefab.GetComponent<Turret>();
        Debug.Log("Standard Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab, turret.cost);
    }

    public void BuyMissileTurret()
    {
        turret = buildManager.missileTurretPrefab.GetComponent<Turret>();
        Debug.Log("Next Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.missileTurretPrefab, turret.cost);
    }

    public void BuyLaserTurret()
    {
        turret = buildManager.laserTurretPrefab.GetComponent<Turret>();
        Debug.Log("L4Z0r Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.laserTurretPrefab, turret.cost);
    }
    #endregion
}
