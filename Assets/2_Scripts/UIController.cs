using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class UIController : MonoBehaviour
{
    /**
     * @ Function : 일정 조건 만족 시 새로운 메세지(쇼핑리스트) 띄우는 함수
     * 
     * @ Author : Euisung Kim
     * @ Date : 2020.04.03
     * @ History :
     *   - 2020.04.03 Euisung Kim : 최초작성
     **/

    private enum State { Yet, Done };       // state that show 1st message or 2nd message
    private State messagingState = State.Yet;   //set up to show 1st message initially

    public GameObject countChecker;     //for checking the total count of stuffs in the trolley
    public GameObject ui_messaging1;    //1st message
    public GameObject ui_messaging2;    //2nd message

    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Action_Boolean trackpadAction;

    // Start is called before the first frame update
    void Start()
    {
        ui_messaging1.SetActive(true);
        ui_messaging2.SetActive(false);

        //Pulse(2, 150, 75, SteamVR_Input_Sources.LeftHand);
    }

    // Update is called once per frame
    void Update()
    {
        
        // 1st message state -> 2nd message state
        if(messagingState == State.Yet && countChecker.GetComponent<ObjectCounter>().totalEA > 4)
        {
            messagingState = State.Done;
            hapticAction.Execute(0, 1, 150, 75, SteamVR_Input_Sources.LeftHand);
            StartCoroutine(SecondUIOnOff());
        }

        // It is just for when control by keyboard ;; nevermind.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UIOnOff();
        }
    }

    public void UIOnOff()       // Functions of UI on/off 
    {
        if (messagingState == State.Yet)
        {
            if (ui_messaging1.activeSelf == true)
            {
                ui_messaging1.SetActive(false);
            }
            else if (ui_messaging1.activeSelf == false)
            {
                ui_messaging1.SetActive(true);
            }
        }

        else if (messagingState == State.Done)
        {
            if (ui_messaging2.activeSelf == true)
            {
                ui_messaging2.SetActive(false);
            }
            else if (ui_messaging2.activeSelf == false)
            {
                ui_messaging2.SetActive(true);
            }
        }
    }
    IEnumerator SecondUIOnOff()
    {
        yield return new WaitForSeconds(1.0f);      // 2nd message will be shown 1(s) after vibration of vive controller.
        ui_messaging1.SetActive(false);
        ui_messaging2.SetActive(true);
    }

}
