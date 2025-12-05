using UnityEngine;

public class Main5 : MonoBehaviour
    // inputAction : 맵핑을 하여서 무슨 키를 누르면 어디로 이동하게 끔 하는 것
    // 하지만 대부분의 게임사는 아직까지 레거시를 사용한다
    // 물론 멀티 플랫폼이면 요즘 방식을 쓰겠지만

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // 매 프레임마다 업데이트
    // Update is called once per frame
    void Update()
    {
        // 키를 누르면 나오게
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    // GetKey : 누르고 있는 동안 계속 신호가 간다
        //    // GetKeyDown : 한번 누를 때 신호가 간다 > KeyCode > 키보드에 있는 모든 키
        //    // GetKeyUp : 손을 뗐을 때 신호가 간다
        //    Debug.Log("A Hold");
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    // GetKey : 누르고 있는 동안 계속 신호가 간다
        //    // GetKeyDown : 한번 누를 때 신호가 간다 > KeyCode > 키보드에 있는 모든 키
        //    // GetKeyUp : 손을 뗐을 때 신호가 간다
        //    Debug.Log("A Down");
        //}
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    // GetKey : 누르고 있는 동안 계속 신호가 간다
        //    // GetKeyDown : 한번 누를 때 신호가 간다 > KeyCode > 키보드에 있는 모든 키
        //    // GetKeyUp : 손을 뗐을 때 신호가 간다
        //    Debug.Log("A Up");
        //}
        /*
         InvalidOperationException: You are trying to read Input using the UnityEngine.
        Input class, but you have switched active Input handling to Input System package 
        in Player Settings.UnityEngine.Input.GetKeyDown (UnityEngine.KeyCode key) 
        (at <ab6544b286b9435b81b90955abcc15f7>:0)
        유니티6부터 input시스템이 new로 바뀌어서 오류가 많이 난다. > old로 하거나 both로 바꿔야한다
        edit - project Setting - player - other setting
         */
        // Update의 특성 상 한 프레임당 계속 반복이기 때문에 if문에 hold가 더 많이 나올 수 밖에 없다

        // 마우스
        //if (Input.GetMouseButton(0)) // 왼쪽 클릭 - 0 오른쪽 클릭 - 1 스크롤 클릭 -2
        //{
        //    Debug.Log("Mouse Hold");
        //}
        //if (Input.GetMouseButtonDown(0)) // 왼쪽 클릭 - 0 오른쪽 클릭 - 1 스크롤 클릭 -2
        //{
        //    Debug.Log("Mouse Down");
        //}
        //if (Input.GetMouseButtonUp(0)) // 왼쪽 클릭 - 0 오른쪽 클릭 - 1 스크롤 클릭 -2
        //{
        //    Debug.Log("Mouse Up");
        //}

        // wasd로 방향 이동
        //if (Input.GetKey(KeyCode.W))
        //{
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //}
        // GetAxis("Horizantal") > 수치값 반환 > 0부터 1사이의 수 
        Debug.Log($"가로 : {Input.GetAxis("Horizontal")}");
        Debug.Log($"세로 : {Input.GetAxis("Vertical")}");
        // Project setting > Input settings



    }
}
