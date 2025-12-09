using UnityEngine;

public class Monster : MonoBehaviour
{
    // 몬스터가 플레어를 따라가게 하려 함
    private Player player; // Start는 한번밖에 못쓰니까 계속 쓰려면 > 멤버변수로

    public float speed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {   
        float moveDistance = speed * Time.deltaTime;// 속도 * 시간 = 거리
        
        // 플레이어의 현재 위치 벡터 에서 나의 위치 벡터를 빼면 플레이어로 향하는 방향벡터가 된다
        Vector3 direction = player.transform.position - transform.position;// 방향 + 크기
                                                                           // 이것은 normalize가 안 되어있음

        transform.position += direction.normalized * moveDistance;
        // 이걸 여러개로 하면 그것이 뱀서 > collision이 없어서 그냥 합쳐지지만
        
        //Debug.Log(direction.normalized);
        //Debug.Log(direction.magnitude);
        // 너무 멀어서 안될 것같은데 망설임
        if(direction.magnitude < 5)
        {
            transform.position += direction.normalized * moveDistance;
        }
        
        // 추적 or 패트롤에 중요한 요소 > 정규화와 거리 구하는 것은 중요하다

        //  거리 내에서 or 시야각 안에서 걸리면 총 발사 등 > 다 이걸로 만드는 거다.







    }

    // 충돌 > Danamic
    private void OnCollisionEnter2D(Collision2D collision) // getKeyDown > 충돌할때
    {
        Debug.Log("[Monster] OnCollisionEnter2D");
    }

    private void OnCollisionExit2D(Collision2D collision)// getKeyUp > 떨어졌을때
    {
        Debug.Log("[Monster] OnCollisionExit2D");
    }
    private void OnCollisionStay2D(Collision2D collision) // getKey > 충돌중일때
    {
        Debug.Log("[Monster] OnCollisionStay2D");
    }

    // 영역 > Kinematic
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[Monster] OnTriggerEnter2D");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("[Monster] OnTriggerExit2D");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("[Monster] OnTriggerStay2D"); // OnCollision과 OnTrigger는 동시에 발생할 수 없다
    }

}
