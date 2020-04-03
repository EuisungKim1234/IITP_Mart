using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    float distance = 0.8f;

    /**
    * @Function: 마우스로 테스트 할 수 있게 수정
    *
    * @Author: Minjung KIM
    * @Date: 2020.02.13
    * @History:
    *  2020-02-13 Minjung KIM: 최초 작성
    */
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.9f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}