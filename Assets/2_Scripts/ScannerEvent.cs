using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScannerEvent : MonoBehaviour
{
    Dictionary<string, string> org_item_list = new Dictionary<string, string>();        // Original item list info: <item_code, item_name>
    Dictionary<string, string> org_item_price = new Dictionary<string, string>();       // Original item price info: <item_name, price>
    Dictionary<string, string> scanned_code_info = new Dictionary<string, string>();    // Scanned item code list: <item_code, item_name>
    Dictionary<string, string> scanned_item_list = new Dictionary<string, string>();    // Scanned item list: <item_name, item_qty;item_price>
    bool update_yn = false;
    public Canvas screen1;
    public Canvas screen2;


    void Awake(){
        // Initialize the item price
        org_item_price.Add("Jelly", "1");
        // Initialze the original item list
        for(int i=1; i<25; i++){
            org_item_list.Add("Jelly"+i, "Jelly");
        }
        org_item_price.Add("Sugar", "3");
        for(int i=1; i<19; i++){
            org_item_list.Add("Sugar"+i, "Sugar");
        }
        org_item_price.Add("Chip", "3");
        for(int i=1; i<13; i++){
            org_item_list.Add("Chip"+i, "Chip");
        }
        org_item_price.Add("Tuna", "10");
        for(int i=1; i<73; i++){
            org_item_list.Add("Tuna"+i, "Tuna");
        }
        org_item_price.Add("Corn", "2");
        for(int i=1; i<41; i++){
            org_item_list.Add("Corn"+i, "Corn");
        }
        org_item_price.Add("Coffee", "5");
        for(int i=1; i<25; i++){
            org_item_list.Add("Coffee"+i, "Coffee");
        }
        org_item_price.Add("Sausage", "3");
        for(int i=1; i<13; i++){
            org_item_list.Add("Sausage"+i, "Sausage");
        }
        org_item_price.Add("Water", "1");
        for(int i=1; i<10; i++){
            org_item_list.Add("Water"+i, "Water");
        }
        org_item_price.Add("Juice", "2");
        for(int i=1; i<16; i++){
            org_item_list.Add("Juice"+i, "Juice");
        }
        org_item_price.Add("Milk", "2");
        for(int i=1; i<10; i++){
            org_item_list.Add("Milk"+i, "Milk");
        }
        org_item_price.Add("Potato", "3");
        for(int i=1; i<19; i++){
            org_item_list.Add("Potato"+i, "Potato");
        }
        org_item_price.Add("Orange", "3");
        for(int i=1; i<21; i++){
            org_item_list.Add("Orange"+i, "Orange");
        }
        org_item_price.Add("Pear", "3");
        for(int i=1; i<16; i++){
            org_item_list.Add("Pear"+i, "Pear");
        }
        org_item_price.Add("Cucumber", "3");
        for(int i=1; i<24; i++){
            org_item_list.Add("Cucumber"+i, "Cucumber");
        }
        org_item_price.Add("Pineapple", "4");
        for(int i=1; i<5; i++){
            org_item_list.Add("Pineapple"+i, "Pineapple");
        }
        org_item_price.Add("Tomato", "2");
        for(int i=1; i<18; i++){
            org_item_list.Add("Tomato"+i, "Tomato");
        }
        org_item_price.Add("Cabbage", "2");
        for(int i=1; i<9; i++){
            org_item_list.Add("Cabbage"+i, "Cabbage");
        }
        org_item_price.Add("Cheese", "4");
        for(int i=1; i<13; i++){
            org_item_list.Add("Cheese"+i, "Cheese");
        }
        org_item_price.Add("Bread", "1");
        for(int i=1; i<54; i++){
            org_item_list.Add("Bread"+i, "Bread");
        }
    }

    void Start(){
        Debug.Log("< Scanner initial Info Load > org_item_list.cnt:"+ org_item_list.Count);
        Debug.Log("< Scanner initial Info Load > org_item_price.cnt:"+ org_item_price.Count);
    }

    void Update(){
        int i = 1;
        int total_amount = 0;
        int discount = 0;

        // 2020.03 MJ: Update the receipt information on the self-checkout screen
        if(scanned_item_list.Count > 0 && update_yn == true){

            // Clear all information on the self-checkout screen
            ClearAllInformation(); 

            foreach(KeyValuePair<string, string> kv in scanned_item_list){ 
                // format: <item_qty;item_price>
                // Receipt UI Format: checkbox1, item_name1, item_qty1, item_price1.. 
                string[] item = (kv.Value).ToString().Split(';');
                GameObject.Find("checkbox"+i).GetComponent<Toggle>().interactable = false;
                GameObject.Find("checkbox"+i).GetComponent<Toggle>().isOn = true;
                GameObject.Find("item_name"+i.ToString()).GetComponent<TextMeshProUGUI>().text = kv.Key;
                GameObject.Find("item_qty"+i.ToString()).GetComponent<TextMeshProUGUI>().text = item[0].ToString();
                GameObject.Find("item_price"+i.ToString()).GetComponent<TextMeshProUGUI>().text = item[1].ToString();
                
                discount = 0;
                total_amount += Int32.Parse(item[0])*Int32.Parse(item[1]);
                i++;
            }
            GameObject.Find("discount").GetComponent<TextMeshProUGUI>().text = discount.ToString();
            GameObject.Find("total_amount").GetComponent<TextMeshProUGUI>().text = total_amount.ToString();            
        }
        // Finish the receipt update 
        update_yn = false;
    }

    /**
     * @Function: Initialize the self-checkout screen
     * @UI Format: L1{checkbox1, item_name1, item_qty1, item_price1}
     * 
     * @Author: Minjung KIM
     * @Date: 2020.Mar.25
     * @History: 
     *  - 2020.03.25 Minjung KIM: Initial commit
     */
    void ClearAllInformation(){
        for(int i=1; i<11; i++){
            GameObject.Find("checkbox"+i).GetComponent<Toggle>().interactable = false;
            GameObject.Find("checkbox"+i).GetComponent<Toggle>().isOn = false;
            GameObject.Find("item_name"+i).GetComponent<TextMeshProUGUI>().text = "";
            GameObject.Find("item_qty"+i).GetComponent<TextMeshProUGUI>().text = "";
            GameObject.Find("item_price"+i).GetComponent<TextMeshProUGUI>().text = "";
        }
        GameObject.Find("discount").GetComponent<TextMeshProUGUI>().text = "0";
        GameObject.Find("total_amount").GetComponent<TextMeshProUGUI>().text = "0";
    }
    
    /**
     * @Function: Item Scanner Function
     * 
     * @Author: Minjung KIM
     * @Date: 2020.Mar.17 
     * @History: 
     *  - 2020.03.17 Minjung KIM: 최초 작성 (1개 타입의 종류만 되도록 개발)
     *  - 2020.03.18 Minjung KIM: 여러 개의 오브젝트가 스캔되도록 개발
     */
    void OnTriggerEnter(Collider collision){
        string o_item_code = collision.gameObject.name;  // unique item code: ex) A1
        string o_item_name = collision.gameObject.tag;   // item name: ex) Apple
        Debug.Log("OnTriggerEnter() o_item_code:" + o_item_code);
        Debug.Log("OnTriggerEnter() o_item_name:" + o_item_name);
        string scan_yn = "N";

        // 1. Check whether items scanned or not (Also blocking the duplicate scan)
        if (!scanned_code_info.ContainsKey(o_item_code) && o_item_name != "Untagged"){

            // 2. Play the scan sound(beep Sound)
            GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();

            // 3-1. If the item is already scanned
            int o_item_qty = 1;
            string o_item_price = org_item_price[o_item_name];
            if(scanned_item_list.ContainsKey(o_item_name)){

                // Load the original information
                string[] org_scanned_info = scanned_item_list[o_item_name].Split(';');
                o_item_qty = Int32.Parse(org_scanned_info[0]) + 1; // 1개 더 더해요.

                // Update original quantity information 
                string item_info = string.Format("{0};{1}", o_item_qty, o_item_price);
                scanned_item_list[o_item_name] = item_info;

            // 3-2. If there is no item information
            }else{

                // Add the new information <item_qty;item_price> format
                string item_info = string.Format("{0};{1}", o_item_qty, o_item_price);
                scanned_item_list.Add(o_item_name, item_info);
            }

            // 4. Add the scanned item code
            scanned_code_info.Add(o_item_code, o_item_name);
            scan_yn = "Y";

        } // Q. 이미 스캔된 오브젝트라고 알려주어야 하는가? (scan_yn)

        // 5. Event logging
        EventLogger.ScanLog(o_item_code, o_item_name, "ADD", DateTime.Now.ToString(), scan_yn);

        // 6. Request the receipt update
        update_yn = true;
    }
    
    /**
     * [Working Memory Task]
     * @Function: Change the screen1(Scan Screen) to screen2(Apply the Reduction code Screen)
     * 
     * @Author: Minjung KIM
     * @Date: 2020.Mar.25
     * @History: 
     *  - 2020.03.25 Minjung KIM: 최초 작성
     */
    public void screen1_btn_next(){

        // 인증 완료여부 확인 
        // if(reduction_auth_yn == false){
            // 미인증 시 - 할인코드 입력 
            screen1.gameObject.SetActive(false);
            screen2.gameObject.SetActive(true);

            // 이때 물건 스캔이 안되도록 막아야 함! 혹은 이미 미 스캔된 항목이 안되도록 블로킹

        // }else{
            // 사용자 메시지는 크게 색 있게 보여줘야할 듯
            // 인증 시 - 디시전 메이킹 시작합니다. (텍스트 노출)
            // 체크박스 풀어주기 

        // }
    }

    /**
     * [Decision Making Task]
     * @Function: Change the screen1(Scan Selection Screen) to screen3(Complted Screen)
     * 
     * @Author: Minjung KIM
     * @Date: 2020.Mar.25
     * @History: 
     *  - 2020.03.25 Minjung KIM: 최초 작성
     */
    public void screen1_btn_final(){
        
        // 선택된 물건을 계산하여 잘못된 물건을 다 제외했는지 확인함 
        // 제외가 모두 완료될 때 까지, 금액을 확인하라는 문구가 노출됨
        // 이벤트 로깅
        if(check_shopping_list()){
            
        }

        // 모두 완료되면 Screen3이 노출됨 > 완료되었습니다. (종료)
        
        // 이벤트 로깅
    }

    bool check_shopping_list(){

        // 쇼핑 목록을 확인합니다.

        // 체크박스에 모두 표기되어있는지 봅니다.

        return true;
    }
}