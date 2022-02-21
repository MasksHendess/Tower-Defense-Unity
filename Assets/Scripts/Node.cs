using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    #region props
    public Color hoverColor;
    public Vector3 positionOffset;
    private Color startColor;
    private Renderer rend;

    private GameObject turret;

    private BuildManager buildManager;
    private Turret turr;
    #endregion
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region MouseEffects
    private void OnMouseEnter()
    {
        // No click behind UI Element
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    { 
        // No click behind UI Element
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        // Build Turret on Node

        // No Turret selected (from shop)
        if (buildManager.GetTurretToBuild() == null)
            return;

        // Node is already ocupied
        if (turret!=null)
        {
            Debug.Log("Can't build there");
            return;
        }

        // Node is buildable, place turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turr = turretToBuild.GetComponent<Turret>();
        var playerHasEnoughCash = buildManager.payForTurretToBuild(turr.cost);
        if (playerHasEnoughCash)
        {
            // GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        }
    }
}
#endregion