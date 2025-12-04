using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.U2D;
// player 스크립트를 만들어주세요
// 멤버변수로 
//int level = 1
//int hp = 100
//int damage = 10 
public class Player2 : MonoBehaviour
{
    //[SerializeField]
    //private Sprite sprite;

    
    public int level = 1;
    
    public int hp = 100;
    public int damage = 10;

    // 하이어라키 상에 플레이어가 있는지 없는지 값을 가져온다




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 이번엔 이미 있는 객체라 가정하고 만들어보자
        // Main에서 선언하면 > Player가  행동하면 되잖아?
        GameObject go = gameObject; // 현재 내가 붙어있는, 기생하고 있는(부모가 되는) GameObject 가져오기
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        //sr.sprite = sprite; 지금은 없으니까 일단 넘어가도록 하자
        //sr.sprite = sprite;
        sr.color = Color.blue;

        // GameObject의 좌표를 0,0,0에서 5,0,0으로 바꿔보자
        //Transform tr = GameObject.Tra
        //Transform tr = go.GetComponent<Transform>();
        Transform tr = transform;
        // >  모든 GameObject는 기본적으로 Transform을 가지고 있으므로
        // 따로 변수화 되어있는 것 > 현대 게임오브젝트의 트랜스폼 가져오기
        tr.position = new Vector3(5, 0, 0);
        //tr.position = Vector3.zero; // zero(0,0,0) / left(-1,0,0) /right(1,0,0) 등등
        // Vector 3 : float값이 세개 모인 것 > 벡터가 생긴다 > 삼차원
        // Vector 2 : float값이 두개 모인 것 > 이차원
        // 벡터 : 공중에 붕 떠있다(좌표 개념) , 방향 개념
        // 이거 사용이 영순위, 제일 우선시 > 로컬 좌표계, 월드 좌표계를 잘 구분해야
        // 이런 것도 패런트, 차일드로 만들 수 있다.
        // UI나 캐릭터 파츠 등등


        // 찾아서 쓰는 것
        






    }

    // Update is called once per frame
    void Update()// 참고로 안 붙어 있는 건 기본적으로 private
    {
        
    }

    
}
