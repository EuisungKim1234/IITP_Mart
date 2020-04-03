using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
    /**
     * @Function : 카트에 담기는 오브젝트 숫자 카운터
     * 
     * @Author : Euisung Kim
     * @Date : 2020.04.03
     * @History : 
     *   - 2020.04.03 Euisung Kim : 최초작성은 아니고, 작성한지 좀 됐는데 이걸 처음 씀
     **/

    public int baguetteEA = 0;
    public int cabbageEA = 0;
    public int cheeseEA = 0;
    public int chipsEA = 0;
    public int coffeeEA = 0;
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
        //Quaternion targetRotation = Quaternion.LookRotation(other.transform.position - this.transform.position, this.transform.up);

        //if (targetRotation.x > 0) Debug.Log("Forward");
        //if (targetRotation.x < 0) Debug.Log("Backward");

        // Debug.Log(other.transform.localPosition);
        // Debug.Log(other.tag);

        //objectCountingState = other.GetComponent<MouseController>().

        
        // by the tag name of object, stuffs and total number are counted
        switch (other.tag)
        {
            case "Baguette":
                baguetteEA++;
                totalEA++;
                Debug.Log("Baguette = " + baguetteEA);
                other.GetComponent<MouseController>().objectState = MouseController.state.chosen;
                break;
            case "Cabbage":
                cabbageEA++;
                totalEA++;
                Debug.Log("Cabbage = " + cabbageEA);
                other.GetComponent<MouseController>().objectState = MouseController.state.chosen;
                break;
            case "Cheese":
                cheeseEA++;
                totalEA++;
                Debug.Log("Cheese = " + cheeseEA);
                other.GetComponent<MouseController>().objectState = MouseController.state.chosen;
                break;
            case "Chips":
                chipsEA++;
                totalEA++;
                Debug.Log("Chips = " + chipsEA);
                other.GetComponent<MouseController>().objectState = MouseController.state.chosen;
                break;
            case "Coffee":
                coffeeEA++;
                totalEA++;
                Debug.Log("Coffe = " + coffeeEA);
                other.GetComponent<MouseController>().objectState = MouseController.state.chosen;
                break;
            case "Cucumber":
                cucumberEA++;
                totalEA++;
                Debug.Log("Cucumber = " + cucumberEA);
                other.GetComponent<MouseController>().objectState = MouseController.state.chosen;
                break;
            case "Tomato":
                tomatoEA++;
                totalEA++;
                Debug.Log("Tomato = " + tomatoEA);
                other.GetComponent<MouseController>().objectState = MouseController.state.chosen;
                break;
            case "Other stuffs":
                otherstuffsEA++;
                totalEA++;
                Debug.Log("Other stuffs = " + otherstuffsEA);
                other.GetComponent<MouseController>().objectState = MouseController.state.chosen;
                break;
        }
        
            
        
    }
}
