using System;
using System.IO;
using System.Text;
using UnityEngine;

public class EventLogger: MonoBehaviour { 
    private static readonly object innerLock = new object(); 
    private static string fileName_scanLog = "ScanLog_"+DateTime.Now.ToString("yyyyMMdd")+".csv";
    private static string fileName_cartLog = "CartLog_"+DateTime.Now.ToString("yyyyMMdd")+".csv";
    private static string fileName_VRControllerLog = "VRControllerLog_"+DateTime.Now.ToString("yyyyMMdd")+".csv";
    private static string fileName = "EventLog_"+DateTime.Now.ToString("yyyyMMdd")+".csv";
    
    /**
     * @Function: initializing the first-column name
     * 
     * @Author: Florian Melki
     * @Date: 2020.03.04
     * @History: 
     *  - 2020.03.04 Florian: 최초 작성
     *  - 2020.03.15 Minjung KIM: 이벤트별 로깅 첫 컬럼 초기화 
     *                            Apptime |^| 로깅 타입(쇼핑, 카트, 스캔, 등) |^| 로깅 타입에 따른 변수 값
     */
	void OnEnable () {
        Debug.Log("Curruent platform:"+Application.platform);

        File.AppendAllText(GetFilePath()+fileName, "AppTime;Actor;Verb;Action\n", Encoding.UTF8);
        File.AppendAllText(GetFilePath()+fileName_scanLog, "AppTime;item_code;item_name;event_type;event_dt\n", Encoding.UTF8);
        // File.AppendAllText(GetFilePath()+fileName_cartLog, "AppTime;Actor;Verb;Action\n", Encoding.UTF8);
        // File.AppendAllText(GetFilePath()+fileName_VRControllerLog, "AppTime;Actor;Verb;Action\n", Encoding.UTF8);
    }
    
    /**
     * @Function: 파일 경로를 가져오는 함수
     * 
     * @Author: Minjung KIM
     * @Date: 2020.03.13
     * @History: 
     *  - 2020.03.13 Minjung KIM: 최초 작성
     *  - 2020.03.28 Minjung KIM: ADD Platform check 
     */
    public static string GetFilePath(){
        String[] orgPath = null;
        String filePath = null;

        if (Application.platform == RuntimePlatform.OSXEditor)
        {
            orgPath = Application.dataPath.Split('/');
            filePath = "/" + orgPath[1] + "/" + orgPath[2] + "/Desktop/IITP_CSV/";
        }
        else if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            orgPath = Application.dataPath.Split('/');
            // Application.dataPath: << C:/Users/admin-user/Desktop/MJ/IITP_Mart_EuisungKIM/IITP_Integrated_Mart/Assets >>
            filePath = "/" + orgPath[1] + "/" + orgPath[2] + "/Desktop/IITP_CSV/";
        }
        return filePath;
    }

    /**
     * @Function: VR 컨트롤러 로깅 함수
     * 
     * @Author: Minjung KIM
     * @Date: 2020.03.15
     * @History: 
     *  - 2020.03.15 Minjung KIM: 최초 작성
     */
    public static void VRControllerLog(
        string user_name        // 1. 사용자
        , string item_code      // 2. 아이템 코드
        , string item_name      // 3. 아이템명
        , string event_type     // 4. 이벤트 타입 : GRAP, TOUCH
        , string start_dt       // 5. 이벤트 시작 시간
        , string end_dt         // 6. 이벤트 종료 시간
    ){        
        lock (innerLock){
            File.AppendAllText(
                GetFilePath()+fileName_VRControllerLog
                , string.Format("{0};{1};{2};{3};{4}", item_code, item_name, event_type, start_dt, end_dt)+"\n"
                , Encoding.UTF8
            );
        }
    }
    
    /**
     * @Function: 계산대 앞에서 아이템 스캔 시, 기록되는 함수
     * 
     * @Author: Minjung KIM
     * @Date: 2020.03.15
     * @History: 
     *  - 2020.03.15 Minjung KIM: 최초 작성
     */
    public static void ScanLog(
        string item_code        // 1. 아이템 코드
        , string item_name      // 2. 아이템 이름
        , string event_type     // 3. 이벤트 종류: DELETE, ADD, UPDATE
        , string event_dt       // 4. 이벤트 발생 시간
        , string scan_yn        // 5. 스캔 등록 여부
    ){
        lock (innerLock){
            File.AppendAllText(
                GetFilePath()+fileName_scanLog
                , string.Format("{0};{1};{2};{3};{4};{5}", Time.realtimeSinceStartup, item_code, item_name, event_type, event_dt, scan_yn)+"\n"
                , Encoding.UTF8
            );
        }
    }

    /**
     * @Function: 쇼핑하면서 카트에 물건을 담고,뺏던 히스토리를 기록하는 함수
     * 
     * @Author: Minjung KIM
     * @Date: 2020.03.15
     * @History: 
     *  - 2020.03.15 Minjung KIM: 최초 작성
     */
    public static void CartLog(
        string item_code        // 1. 아이템 코드
        , string item_name      // 2. 아이템 이름
        , string start_dt       // 3. 
        , string end_dt         // 4. 
    ){        
        lock (innerLock){
            File.AppendAllText(
                GetFilePath()+fileName_cartLog
                , string.Format("{0};{1};{2};{3};{4}", Time.realtimeSinceStartup, item_code, item_name, start_dt, end_dt)+"\n"
                , Encoding.UTF8
            );
        }
    }

    /**
     * @Function: 이벤트 발생 시 기록하는 함수 (주로 어드민 로깅용으로 특정 아이템 및 제한 발생 시, 기록됨)
     * @Example : EventLogger.EventLog(new EventLog("user", "take", "apple"));
     
     * @Author: Florian Melki
     * @Date: 2020.03.04 
     * @History: 
     *  - 2020.03.04 Florian: 최초 작성
     *  - 2020.03.04 Minjung KIM: 파일 경로 가져오는 함수 추가
    //  */
    // public static void EventLog(
    //     EventLog e
    // ){
    //     lock (innerLock){
    //         File.AppendAllText(
    //             GetFilePath()+fileName
    //             , String.Format("{0};{1};\n", Time.realtimeSinceStartup, e.ToString())
    //             , Encoding.UTF8
    //         );
    //     }
    // }
}