using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyController : MonoBehaviour
{
    Transform cameraPos;
    Vector3 cameraVector;
    public GameObject trolley;
    public float camHeight;     // put in y value of "ViveCameraRig", or seek proper value

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()   // trace the main camera's position
    {
        cameraPos = GameObject.Find("ViveCameraRig").GetComponent<Transform>();
        cameraVector = GameObject.Find("ViveCameraRig").GetComponent<Transform>().position;

        TrolleyPositioning();
    }

    private void TrolleyPositioning()   // By user(main camera)'s position, the trolley is located at proper position.
    {
        if(cameraPos.localPosition.x < 0.5f)
        {
            trolley.GetComponent<Transform>().position = new Vector3(cameraVector.x, (cameraVector.y) - camHeight, (cameraVector.z) + 0.6f);
        }
        else if(cameraPos.localPosition.x >= 0.5f && cameraPos.localPosition.z >= 1.75f)
        {
            trolley.GetComponent<Transform>().position = new Vector3((cameraVector.x) + 0.6f, (cameraVector.y) - camHeight, cameraVector.z);
            trolley.GetComponent<Transform>().rotation = Quaternion.Euler(0, 270, 0);
        }
        else if(cameraPos.localPosition.x >= 0.5f && cameraPos.localPosition.z < 1.75f)
        {
            trolley.GetComponent<Transform>().position = new Vector3(cameraVector.x, (cameraVector.y) - camHeight, (cameraVector.z) - 0.6f);
            trolley.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
