using UnityEngine;

public class Main11 : MonoBehaviour
{
    Player3 player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindAnyObjectByType<Player3>();
    }

    // Update is called once per frame
    void Update()
    {
        #region 레이캐스팅과 월드좌표
        //if(Input.GetMouseButtonDown(0)) // 마우스 클릭 감지 0- 왼쪽 1- 오른쪽 2 - 휠
        //{
        //     //Debug.Log(Input.mousePosition);// 우측 상단이 제일 큰 값, 좌측 하단이 제일 작은값
        //     // 하지만 이것은 화면상의 좌표 > 월드 좌표가 아니다
        //     // 그럼 어떻게 월드 좌표(인게임 좌표)로 치환해야할까? > 계산이 필요하다 > 오쏘그래픽
        //     // 다행히도 유니티에는 함수가 있다
        //     // 우리가 하는 2D는 실은 3D로 z축은 존재한다. 다만 그게 0일뿐
        //     // 2D게임을 만들때는 반드시! 끝에 2D가 쓰여있는 기능을 써라.
        //     Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     // 가장 처음 만든 카메라를 메인카메라라 한다 > 그걸 가져오는 기능
        //     // The first enabled Camera component that is tagged "MainCamera" (Read Only).
        //     // ScreenToWorldPoint : 스크린 좌표를 월드 좌표로 변환
        //     // Vector3로 반환해줌 > 받아오자

        //     //Debug.DrawRay(worldPos, Vector3.forward * 100, Color.red, 3); // 비쥬얼라이징하는 거임
        //     // 이것은 2D 전용이 아니라서 > zero로 하면 안된다 > dir : 방향과 크기를 같이
        //     // Debug.DrawRay(기준점, 방향 * 크기, 색상, 유지시간); > 참고로 빌드시에는 안 보임
        //     //Debug.DrawRay(player.transform.position, Vector3.right * 100, Color.red, 3); // 비쥬얼라이징하는 거임
        //     //RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector3.zero); // 안쪽으로 통과시키겠다 
        //     RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector3.right);
        //     // 레이저를 쏘는 기능 > 기준점을 잡아서 어느 방향으로 쏠건가 > 우리는 z축이 필요하다 > 방향을 입력 x
        //     // 다만 이때는 레이저가 안 보인다 > Debug.DrawRay 같이 써야 심상에 좋다

        //     // 레이저만 쏠 수 있는 건 아니다
        //     //RaycastHit2D hit = Physics2D.BoxCast(박스로) /CircleCast(원으로)

        //     if (hit.collider != null) // 맞아서 부딪힌 애가 null이 아니라면
        //     {
        //         Debug.Log(hit.collider.name); // 그 이름을 Log로 반환해주세요
        //     }
        #endregion

        // 애니메이션
        // 스트라이프 애니메이션
        // 스파인 애니메이션 : 스파인 툴로 제작
        

    }
}

