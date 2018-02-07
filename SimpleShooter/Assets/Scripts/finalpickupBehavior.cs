using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalpickupBehavior : MonoBehaviour {
    public UIBehavior ui;
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            print("Stopping...");
            ui.StopPlaying();
            Destroy(this.gameObject);
        }
    }

}
