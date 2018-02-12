using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveonClick : MonoBehaviour
{
    public List<Transform> waypointList;
    public float WhiskerLength = 3.0f;
    public float CloseEnoughlength = 0.5f;
    //public float searchlength = 50.0f;

    public float chaseSpeed = 2.0f;
    public Camera maincam;
    public LayerMask mask;

    public GameObject waypoint1;
    Transform waypointA;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayhit;
            if (Physics.Raycast(ray, out rayhit))
            {
                Vector3 newPosition = new Vector3(rayhit.point.x, 0, rayhit.point.z);
                GameObject way = Instantiate(waypoint1, newPosition, new Quaternion(0, 0, 0, 0));
                waypointList.Add(way.transform);
            }
        }

        if (waypointList.Count > 0)
        {
            System.Predicate<Transform> pred = checkIfActive;
            waypointA = waypointList.Find(pred);
            RaycastHit waypoint;
            Vector3 direction = waypointA.position - transform.position;
            direction = direction.normalized;
            transform.position += direction * chaseSpeed * Time.deltaTime;
            if (Physics.Raycast(transform.position, waypointA.position, out waypoint, CloseEnoughlength, mask.value))
            {
                GameObject buffer = waypointA.gameObject;
                waypointList.Remove(waypointA);
                Destroy(buffer);
                waypointA = waypointList.Find(pred);
                // TODO (someday): Have it avoid hitting obstacles
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward + transform.right / 2) * WhiskerLength);
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward + -transform.right / 2) * WhiskerLength);
    }

    private bool checkIfActive(Transform trn)
    {
        if (trn.gameObject.activeInHierarchy)
        {
            return true;
        }
        else return false;
    }
}
