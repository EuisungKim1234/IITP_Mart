using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private enum state { ready, chosen };
    private state objectState = state.ready;

    public string tagName;

    Transform trolleyTransform;

    public void Start()
    {
        tagName = this.gameObject.tag + "EA";
        //Debug.Log(tagName);
    }

    public void Update()
    {
        // tracing the trolley's position
        trolleyTransform = GameObject.Find("Trolley").GetComponent<Transform>();
    }

    private void OnMouseUp()    // the object's postion is changed to little bit upper postion of the trolley when user click the object, so that the object fall into trolley by the gravity.
    {
        print("마우스 클릭");

        float randomX = Random.Range(-0.09f, 0.09f);
        float randomZ = Random.Range(-0.33f, 0.14f);

        if (objectState == state.ready)
        {
            this.gameObject.transform.position = new Vector3((trolleyTransform.position.x)+randomX, (trolleyTransform.position.y) + 0.8f, (trolleyTransform.position.z)+randomZ);
            Debug.Log(trolleyTransform.name);
            this.gameObject.transform.parent = trolleyTransform;    // change the object's hierarchy to Trolley's child
            objectState = state.chosen;
        }

        // If the object is in the Trolley and the object is selected by User mouse, then the object will be destroyed and the count is counted out.
        else if(objectState == state.chosen)
        {
            switch(tagName)
            {
                case "BaguetteEA":
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().baguetteEA--;
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().totalEA--;
                    break;
                case "CabbageEA":
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().cabbageEA--;
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().totalEA--;
                    break;
                case "CheeseEA":
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().cheeseEA--;
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().totalEA--;
                    break;
                case "ChipsEA":
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().chipsEA--;
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().totalEA--;
                    break;
                case "Coffee beanEA":
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().coffeebeanEA--;
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().totalEA--;
                    break;
                case "CucumberEA":
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().cucumberEA--;
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().totalEA--;
                    break;
                case "TomatoEA":
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().tomatoEA--;
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().totalEA--;
                    break;
                case "Other stuffsEA":
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().otherstuffsEA--;
                    GameObject.Find("CountChecker").GetComponent<ObjectCounter>().totalEA--;
                    break;
            }

            Destroy(this.gameObject);

        }
    }

}
