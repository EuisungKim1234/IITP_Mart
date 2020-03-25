using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;
    //private float r = 0.0f;

    private Transform tr;
    

    public float moveSpeed = 10.0f; //이동속도 변수
    public float rotSpeed = 80.0f;  //회전속도 변수

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        //r = Input.GetAxis("Mouse X");    마우스로 화면 전환하고 싶으면 사용

        Vector3 moveDir = (Vector3.forward * v);

        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);

        tr.Rotate(Vector3.up * rotSpeed * Time.deltaTime * h);

        
    }


}
