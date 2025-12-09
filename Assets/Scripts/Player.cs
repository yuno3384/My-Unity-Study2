using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position += new Vector3(5, 0, 0);// 이동 딱 한 프레임

        // 어우 이건 너무 빨라요 > 한 프레임에 이동할 거리를 만들어 줘야 한다.
        // 이동거리 = 속도 * 시간
        // 한프레임에 움직일 시간 > 한 프레임이 몇 시간인데?
        // Time.deltaTime으로 구하자 : 이전 프레임에서 현재 프레임까지 걸린 시간
    }
    /*
     W: 위 (Up) / 앞 (Forward)
     A: 왼쪽 (Left)
     S: 아래 (Down) / 뒤 (Backward)
     D: 오른쪽 (Right)
     
     */
    // Update is called once per frame
    void Update()// 매 프레임 확인 > 거 너무 빠른디요? > 왜 일까?
        // 매 프레임 이동하는 거니까 >엄청 많이 감지한 > 1초만 해도 60프레임
        // 한프레임에 움직일 시간 > 한 프레임이 몇 시간인데?
        // Time.deltaTime으로 구하자 : 이전 프레임에서 현재 프레임까지 걸린 시간
    {

        float moveDistance = speed * Time.deltaTime; // 속도를 조절하여 > 거리를 줄인다
        // Update : 프레임단위가 바뀔 수 있다 > Time.deltaTime으로 속도를 보장해준다
        // fixedUpdate : 프레임단위를 고정해준다
        // 자세히 보면 대각선이 더 빠르다 > if문이 실행되기 때문 > 이걸 고쳐줘야한다
        // 방향을 취합하고 한번에 방향을 적용하자
        Vector3 moveDirection = Vector3.zero; // Vector3(0,0,0)
        // >> 아무 방향도 없는 방향벡터 생성


        // 플레이어를 이동시켜보자
        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("이건 W키야");
            // w는 y축 +> 위로
            //transform.position += new Vector3(0, moveDistance, 0);
            //moveDirection += new Vector3(0, 1, 0);
            moveDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            //Debug.Log("이건 A키야");
            //transform.position += new Vector3(-moveDistance, 0, 0);
            //moveDirection += new Vector3(-1, 0 , 0);
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("이건 S키야");
            //transform.position += new Vector3(0, -moveDistance, 0);
            //moveDirection += new Vector3(0, -1, 0);
            moveDirection += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("이건 D키야");
            //transform.position += new Vector3(moveDistance, 0, 0);
            //moveDirection += new Vector3(1, 0, 0);//계속 new되어서 객체 증가로 성능이 저하
            moveDirection += Vector3.right;
        }
        // 값이 너무 크다
        transform.position += moveDirection.normalized * moveDistance;// 이동할 방향 벡터 만들기

        // 방향, 크기 벡터는 자유자재로 만들 수 있을 정도로 연습해야 한다.

        // 추적
        // 어떤 버튼을 눌렀을때 > 누르지 않고 어떤 방향으로만 이동시키는 것
        // 투사체를 만들어서 그걸 따라가 보자

    }

    // 이들은 RigidBody와 Collision이 에디터에 붙지 않으면 안 나온다

    // 충돌 > Danamic
    private void OnCollisionEnter2D(Collision2D collision) // getKeyDown > 충돌할때
    {
        Debug.Log("[Player] OnCollisionEnter2D");
    }

    private void OnCollisionExit2D(Collision2D collision)// getKeyUp > 떨어졌을때
    {
        Debug.Log("[Player] OnCollisionExit2D");
    }
    private void OnCollisionStay2D(Collision2D collision) // getKey > 충돌중일때
    {
        Debug.Log("[Player] OnCollisionStay2D");
    }

    // 영역 > Kinematic
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[Player] OnTriggerEnter2D");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("[Player] OnTriggerExit2D");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("[Player] OnTriggerStay2D");
    }
}
