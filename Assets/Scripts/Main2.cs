using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Main2 : MonoBehaviour
{
    // 인스펙터에서 노출되게끔 Sprite변수를 만들어주시고 이름은 sprite로 해주시고
    // , 유니티 에디터에서 텍스쳐를 연결해주세요 
    //>> Main이라는 이름을 가진 GameObject속 MonoBehaviour에 있는 
    [SerializeField]
    private Sprite sprite;
    // Sprite가 어딨는지 모를때 UI에서 도형을 만들고
    // 그 SpriteRenderer안에 있는 이름을 누르면 그 경로로 이동한다

    //public GameObject player; // 클래스 멤버변수 : m 또는 _ 라고 컨벤션을 한다 주로
    //public Player2 player; // 하나만 없애는 게 아니라 > 여러명이라면
    public List<Player2> players = new List<Player2>();
    public int[] ints = new int[4];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #region

        // 이제 코드상에서 구현을 해서 에디터에서 작업 없이 해보자
        GameObject go = new GameObject();// hierachy창에서 create Empty와 동일 > 빈 게임오브젝트 생성
                                         // play시에만 생김 > 동적 할당
                                         // 이들은 스코프를 떠나면 소멸한다 > 상위스코프로 올린다.
        go.name = "Player"; // 메모리 상으로만 들고 있던 것 + 하이어라키에서 추가
                            // 좌표가 항상 초기값 위치에 서겠구나
                            // sprite Renderer를 구현해보자 > 모양 넣기
                            // AddComponent<제네릭->타입> => 제네릭 속 값이 반환 값이다
                            //go.AddComponent<SpriteRenderer>(); // GameObject에 컴퍼넌트 붙이기
                            //SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
                            // 도형도 바꾸고 색상도 변경해주고 하려면 > 변수에 집어넣으면 된다
                            // GameObject에 붙여있는 컴포넌트를 가져와보자
                            //go.GetComponent<SpriteRenderer>();
                            //SpriteRenderer sr2 = go.GetComponent<SpriteRenderer>();
                            // 해당하는 컴포넌트가 있다면 반환, 만일 컴포넌트가 없는 상태면 > null상태로 들어옴
                            // 만일 받아오지 않으면 계속 반복해야하니까. > 미리 받아놓자


        // 이제 Sprite를 받아오자
        //sr.sprite = sprite;// 물론 받아오는 방법을 모르지만...
        // 1. 경로를 가져오는 법을 모를때 - Sprite변수 속 에서 에디터로 가져온 값을 그대로 넣는다

        //sr.color = Color.green;// Color class로 정해진 색깔로 하기
        // 나중엔 프리셋으로 미리 만들거다 이를 프리펩이라 한다

        // player 스크립트를 만들어주세요
        // 멤버변수로 
        //int level = 1
        //int hp = 100
        //int damage = 10 

        // go에다가 Player 컴퍼넌트를 붙여주세요
        //Player2 player = go.GetComponent<Player2>();
#endregion
        CreatePlayer();
        CreatePlayer();
        CreatePlayer();
        CreatePlayer();
        CreatePlayer();
        CreatePlayer();


        int index = Random.Range(0, 10);//Next(0,10)와 유사
        // hidden으로 처리해서 안보이게 할 뿐
        RemovePlayer(players[index]);// 안전하게 삭제가 된다
        // 리소스 관리는 만든 곳에서 삭제한다. > 만드는 것도 따로, 삭제도 따로
        // 실행만 Main에서

    }
    //모듈화 > 함수에 담는 것
    void CreatePlayer()
    {
        GameObject go = new GameObject();
        go.name = "Player";
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;
        sr.color = Color.green;
        Player2 player = go.AddComponent<Player2>();
        player.level = 2;

        players.Add(player);

        #region GameObject 삭제법 과 비활성화 방법
        // 보이는 것은 Delete를 하면 되지 > 코드로는?
        //GameObject.Destroy(go); // 특정 게임오브젝트, 컴포넌트를 삭제하는 함수 > 즉시삭제
        //GameObject.Destroy(player, 3); //특정 게임오브젝트, 컴포넌트를 삭제하는 함수 > 특정 초 이후에 삭제
        // 받는 것이 Object > 하지만 모든 것이 Object이므로 다 받아주는 거다
        // 내가 만든 class도 object이므로 > 이것도 작동함
        // 특정 컴포넌트도 삭제가 가능하다

        // 유니티를 쓰지만 게임회사가 아닌 경우 > 공장자동화라든가
        // 이것이 필요한데 이게 없는데 > 구현하려면 > 바로 삭제해야해서...

        //GameObject.Destroy(sr, 3); // SpriteRenderer도 삭제된다

        // 비활성화
        // inspector 옆에 체크표시로 없애고 보이고 할 수 있다
        // 오브젝트 풀링 : 계속 생성만 하면 메모리가 꽉 차겠지? 차라리 비활성화하고 재활용하자
        // 자 그럼 코드로는?
        //go.SetActive(false); // true면 활성화, false면 비활성화
        // 에디터 상의 눈표시(visible)과 비활성화는 다르다
        #endregion
        
        // 인스턴스 관리
        // 어떻게 하면 이 객체들을 체계적으로 관리할 수 있을까
        //this.player = go; //오류가 나는데? 
        //지역변수와 멤버변수의 충돌 > this로 해결
        //이는 간편화하고자 변수를 만들고 참조값으로 그걸 변경하는 식이다.
        // 다른 함수에서 사용시에 멤버변수만 사용하겠다.는 편리한 점이 있다.
        // 또 따로 getComponent를 반복하니 > 해당 타입의 객체를 미리 선언하는 방식으로 가자






    }
    #region GameObject 찾기 : find(), FindWithTags()
    // 근데 OOP의 원칙에 따르면 너무 Main()에만 있는데... > 객체의 기능을 다 분리해줘야 한다
    // CreatePlayer는 Main이 가질 기능은 아닐 것이다.(Player만들려고 만든 거니까..)
    // > 따로 빼서 Player만을 위해
    // Update is called once per frame

    void Test()
    {
        //go. > 못찾는다
    }

    //private void Update()
    //{
    //    //GameObject go = GameObject.Find("Player");// static이라 그렇다
    //    // 하이어라키 상에서 같은 이름이 있으면 해당 객체를 가져오고, 없으면 null을 반환한다
    //    // 이름으로 찾는 것이 제일 느리다
    //    // 유니티에는 Tag와 Layer가 존재한다 > 네임택을 가지고 찾겠다
    //    //GameObject go = GameObject.FindGameObjectWithTag("Study");
    //    // FindGameObjectWithTag : 태그로 찾는 녀석
    //    //하이어라키 상에서 찾는 단어와 같은 태그가 있으면 해당 객체를 가져오고,
    //    //없으면 null을 반환한다

    //    // 세번째로 찾는 법
    //    Player2 player2 = GameObject.FindAnyObjectByType<Player2>();
    //    // 이 타입을 갖고있는 GameObject를 반환해줘
    //    //하이어라키 상에서 찾는 단어와 같은 태그가 있으면 해당 객체를 가져오고,
    //    //없으면 null을 반환한다

    //    // Layer도 있다 > Layer는 공간을 나타낸다 보면 된다
    //    //GameObject.Find > 레이어로 찾는 방법은 없다.

    //    if (player2 != null)// null체크
    //    {
    //        // 게임오브젝트(go)에서 Player 컴포넌트를 가져와서 player란 변수에 저장하기
    //        //Player2 player2 = player2.GetComponent<Player2>();

    //        Debug.Log("Found Player");

    //        // 이번엔 게임오브젝트를 삭제해보자 > 디스폰
    //        // 투사체가 날아갔다면 어느 범위를 넘어가면 없애야하니까

    //    }
    



    //}
#endregion


    float t = 0;
    private void Update()
    {
        // Player라는 게임오브젝트를 찾아서 3초뒤에 비활성화 하고 
        // 5초뒤에 삭제되는 코드를 작성해주세요
        //GameObject go = new GameObject();
        //Player2 player2 = GameObject.FindAnyObjectByType<Player2>();
        GameObject go = GameObject.Find("Player");
        //go.AddComponent<Player2>();

        //t += Time.deltaTime;
        //if(t > 3 && go != null)
        //{
        //    go.SetActive(false);
        //    t = 0;

        //    GameObject.Destroy(go, 5);
        //}


        //인스턴스 관리법
        //하나를 만들어 놓고 멤버변수로 사용케 한다
        //player.hp > 못 가져오는데요??
        //this.player.GetComponent<Player2>().hp++;//이런 식으로 가져와야 한다
        // 그래서 값이 계속 올라가는 참사가.... > 공격이 될 수도 있고
        // 하지만 GetComponent도 언제나 호출하기엔 부담스럽다
        // 그래서 Component로 만들어서 그걸 관리케 한다
        Player2 player3 = go.GetComponent<Player2>(); //주로 이렇게 활용하는 방식으로 해라
        // 멤버 변수로 만들고 그걸 소환하는 방식으로 > 에디터에서 연결해서 사용하는 방법이 제일 낫다
        //player3.hp++; // 이거 무시되는데요? 
        // 멤버 삭제 
        GameObject.Destroy(player3,3);
        // Destroy를 해도 처음엔 완전히 지우는 게 아니라 참조주소는 그대로 들고 있고
        // 대신 그 자리에 null을 넣어둔다. > 이를 fakeNull이라 한다

        //if(player != null) //문제는 fakenull과 진짜null은 다른데
        //                   // 오퍼레이터 > 연산자 오버로딩이 발생한다
        //                   // != > 재정의 > 서로 다른 null도 정의할 수 있게
        //                   // 그래서 fakeNull도 null처리가 된다
        //{
        //    GameObject go4 = player.gameObject;//이것은 null이다
        //    player.hp++; // MissingReference 가 발생한다
        //}
       
        // player 1  player2
        //  int id   int id
        // 객체로 비교하면 별 의미가 없는건데 > 연산자 오버로딩을 통해 id끼리 비교하게 하는 방법

        // 반복문 - while / for / foreach(배열에서 하나씩 꺼내는 형식)
        foreach(Player2 p in players) // players 안에 있는 각각 추가된 요소를 
                                      // Player2 타입의 p에 각각 넣어주세요
        {
            //p.hp++;
            GameObject go5 = p.gameObject; // 삭제하는 걸 잘 기억해야함 > Missing 에러가 남
           

        }
        //for(int i = 0; i < players.length ; i++) 이런 방식임

    }
    // 생성과 삭제는 원래 다른 곳에서 해야한다 > 강제로 한 공간으로 정하고
    private void RemovePlayer(Player2 player)
    {
        GameObject.Destroy(player);
        players.Remove(player);
    }







}
