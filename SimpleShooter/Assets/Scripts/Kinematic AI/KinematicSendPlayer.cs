using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSendPlayer : MonoBehaviour
{
    public KinematicCore core;
    public WaypointController way;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000, 1 << LayerMask.NameToLayer("Floor"))) 
            {
                if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
                {
                    core.Flee(hitInfo.point);
                }
                else
                {
                    core.Seek(hitInfo.point, true);
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            way.ToggleActive();
        }
    }
}
