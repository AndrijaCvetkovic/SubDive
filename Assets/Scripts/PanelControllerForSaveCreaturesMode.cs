using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControllerForSaveCreaturesMode : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> creaturesToSave;

    public void MissionAlreadyCompleted()
    {
        creaturesToSave = new List<GameObject>();
    }
    
}
