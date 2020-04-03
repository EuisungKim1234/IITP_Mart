using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyboardEvent : MonoBehaviour
{
    public Canvas screen1;
    public Canvas screen2;
    public TMP_InputField input_field;
    public Button screen2_key_1;
    public Button screen2_key_2;
    public Button screen2_key_3;
    public Button screen2_key_4;
    public Button screen2_key_5;
    public Button screen2_key_a;
    public Button screen2_key_b;
    public Button screen2_key_c;
    public Button screen2_key_d;
    public Button screen2_key_e;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 키 입력을 받아서 자동으로 업데이트 해줌 
        // 자릿수 제한 
        // Debug.Log("");
        // screen2_key_1.onClick.AddListener()

        // 이벤트 로깅 (키 삭제 및 시도에 대한 모든 테스크)
    }

    void key_a(){

    }

    void key_b(){

    }

    void key_c(){

    }

    void key_d(){

    }

    void key_e(){

    }
    

    void key_1(){

    }
    
    void key_2(){

    }
    

    void key_3(){

    }
    

    void key_4(){

    }
    

    void key_5(){

    }

    public void screen2_btn_apply(){
        
        Debug.Log("Btn2_text입니다.");
        
        // 입력키가 정확한지 3번 트라이얼 확인
        
        // 할인코드가 일치할 경우 화면 전환
        screen1.gameObject.SetActive(true);
        screen2.gameObject.SetActive(false);

        // 인증완료에 대한 값 설정
        
        // 이벤트 로깅 (키 삭제 및 시도에 대한 모든 테스크)
    }
}