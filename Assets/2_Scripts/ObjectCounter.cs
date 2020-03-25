using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
    public int baguetteEA = 0;
    public int cabbageEA = 0;
    public int cheeseEA = 0;
    public int chipsEA = 0;
    public int coffeebeanEA = 0;
    public int cucumberEA = 0;
    public int tomatoEA = 0;
    public int otherstuffsEA = 0;
    public int totalEA = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Quaternion targetRotation = Quaternion.LookRotation(other.transform.position - this.transform.position, this.transform.up);

        if (targetRotation.x > 0) Debug.Log("Forward");
        if (targetRotation.x < 0) Debug.Log("Backward");

        Debug.Log(other.transform.localPosition);
        Debug.Log(other.tag);

        // by the tag name of object, stuffs and total number are counted
        switch (other.tag)
        {
            case "Baguette":
                baguetteEA++;
                totalEA++;
                Debug.Log("Baguette = " + baguetteEA);
                break;
            case "Cabbage":
                cabbageEA++;
                totalEA++;
                Debug.Log("Cabbage = " + cabbageEA);
                break;
            case "Cheese":
                cheeseEA++;
                totalEA++;
                Debug.Log("Cheese = " + cheeseEA);
                break;
            case "Chips":
                chipsEA++;
                totalEA++;
                Debug.Log("Chips = " + chipsEA);
                break;
            case "Coffee bean":
                coffeebeanEA++;
                totalEA++;
                Debug.Log("Coffe bean = " + coffeebeanEA);
                break;
            case "Cucumber":
                cucumberEA++;
                totalEA++;
                Debug.Log("Cucumber = " + cucumberEA);
                break;
            case "Tomato":
                tomatoEA++;
                totalEA++;
                Debug.Log("Tomato = " + tomatoEA);
                break;
            case "Other stuffs":
                otherstuffsEA++;
                totalEA++;
                Debug.Log("Other stuffs = " + otherstuffsEA);
                break;
        }

        
    }
}
