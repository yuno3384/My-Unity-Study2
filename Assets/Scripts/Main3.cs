// 이제 sprite를 유니티 에디터에서 드래그 앤 드롭말고 코드로 해보자
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    //public Sprite sprite;
    // 에디터의 Asset에서 Resources 폴더를 만들어 sprite를 넣자

    //public GameObject prefeb;// 프리펩은 GameObject의 저장본!!

    public Button testButton;// using UnityEngine.UI;

    public RectTransform canvasRect; // 캔버스 크기 가져오려고

    private void Start()
    {
        //CreateNewPlayer();
        // 프리펩을 코드상으로 갖고 오는 작업
        // 파일에 Load하는 방법
        #region 프리펩을 연결하고 만드는 법
        // prefeb에다가 빙금 올린 프리펩을 연결(변수에 담는 것)해주세요
        //prefeb = Resources.Load<GameObject>("Player");
        //prefeb = Resources.Load<GameObject>("Prefebs/Player"); // 하지만 이것은 하드코딩이다
        // 만일 경로가 바뀌었거나, 아니면 삭제되면 바로 터진다. ArgumentException
        // 그래서 새로 나온 방법이 있지만 이거 많이 쓴다
        // 에디터에서 프리펩을 누르면 프리펩만의 월드로 들어간다 > 프리펩을 수정할 수 있다.
        // 만일 수정했을 경우 코드 제외 에디터에서 직접 소환시 Override기능이 나온다
        // 월드에서 수정한 것은 자동 적용이지만, 메인월드에서 프리펩에 조작한 것은 override를 해줘야한다
        //prefeb = Resources.Load<GameObject>("");
        //> 주의) 이거 자체가 Assets/Resources에서 찾겠다는 것이므로 경로는 Resources부터 적는다!
        // 저장본이므로 반드시 GameObject방식으로 가져와야 한다

        // 유니티를 빌드할 때 사용한 파일만 압축해서 넣어주고, 안 쓴 것은 알아서 Asset에 넣어둔다.
        // 근데 Resources에 넣어두면 몽땅 다 압축이 된다. 
        // 무조건 사용할 리소스만 넣어둬라...
        #endregion
        // 프리펩이 있으므로 스폰만 하면 된다 > 스폰 함수
        //CreateNewPlayer();

        // UI를 배워보자
        // 버튼을 코드로 가져와 보자

        //testButton.onClick.AddListener(Test);
        testButton.onClick.AddListener(OnClickButton);

        // UnityAction > 함수의 이름을 넣어달라
        // 함수형태가 아님 > 이것이 델리게이트




    }
    float t = 0.0f;
    float timeUp = 3.0f;
    bool isButtonPushed = false;
    private void Update()
    {
        t += Time.deltaTime;

        if (t >= timeUp)
        {
            isButtonPushed = true;

            t = 0;

            Test();
        }
    }
    //public을 써야 inspector에서 노출이 안된다 > 직렬화
    // 하지만 같은 class내니까 문제가 없다
    
    private void OnClickButton()
    {
        // 시간이 지나면 다른 위치로 이동하라
        Debug.LogAssertion("두더지 잡았다.");

        if (isButtonPushed)
        {
            Debug.Log("앗, 잡혀버렸네");
            Test();
        }


    }
    
    
    // 두더지 게임
    void Test()
    {

        //Debug.LogAssertion("버튼 눌렀음");
        Debug.LogAssertion("두더지 이동중");

        //버튼의 크기(RectTransform) 구하기 > 에디터에서 Canvas것을 구하기
        RectTransform rt = testButton.GetComponent<RectTransform>();

        // 버튼의 위치를 변경하라 > 랜덤한 좌표 구하기
        float x = UnityEngine.Random.Range(-canvasRect.rect.width /2/*캔버스 사각형의 가로 절반*/ ,canvasRect.rect.width / 2);
        float y = UnityEngine.Random.Range(-canvasRect.rect.height / 2/*캔버스 사각형의 세로 절반*/ , canvasRect.rect.height / 2);

        // 버튼의 포지션에다가 위에서 구한 랜덤한 좌표를 넣어주기
        rt.anchoredPosition = new Vector2(x,y);
        // 왼쪽으로 가면 - , 오른쪽으로 가면 +

       

        // 외주 > 마트에서 만드는 룰렛 게임 > 150~200 정도를 받는다
    }
    void CreateNewPlayer()
    {
        //GameObject go = Object.Instantiate(prefeb); // 생성함수 > 프리펩과 일치하는 복제품을 생성하는 함수
        // GameObject를 반환하니 받아야 한다
        //go.name = prefeb.name; // 프리펩의 이름을 그대로 받는다.
        #region Sprite를 에디터 사용없이 어떻게 가져올 것인가
        //GameObject go = new GameObject();


        //go.name = "Player";

        //SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        //spriteRenderer sr = go.GetComponent<spriteRenderer>();
        //sr.sprite = sprite; // 자 이제 이걸 어떻게 가져올 것인가
        // Resources.Load<타입명>("이름 또는 경로")
        // > Asset아래 Resources폴더 에 있는 메모리를 들고 오는 기능
        // /Assets/Resources/Circle
        //sr.sprite = Resources.Load<Sprite/*가져올 파일의 타입*/>("Circle"/*파일이 있는 경로*/);// 이것은 유니티 기능이다.
        // 만약에 Resources 폴더에 폴더를 만들고 그리고 그게 들어가 있으면? 
        //  ㄴ sr.sprite = Resources.Load<Sprite>("sss/Circle");로 적는다
        //sr.color = Color.green;
        // 총 용량은 7기가지만 > 메모리에 올리는 것은 일부분만 올리는 방식 > 이것이 리소스
        // 그 파일을 찾기 위해 메모리에 가져오는 방식

        // 어드레서블 > Resource.Load는 예전 것이다 이것이 최신 대세다
        //Addresable > 하지만 이것은 고급 문법이라 나중에...
        //LoadAsync(로드 어씽크) > 용량이 클때 한꺼번에 뜨지 않을때
        // 만일 Load로 하면 멈췄다 나올때까지 기다리게 될 것
        // 그래서 개발된 것 자세한 것은 비동기 이후에
        #endregion
        // 프리펩 : 에디터에서 하나만 제작하고 그것을 Resources에 담아둔 객체 틀
        // 만일 이것이 여러개이라면?
        // 에디터 말고 복제하는 방법
        // Assets/Resources에 그냥 끌어 땡겨 > 이제 그것은 prefeb이 된거다
        // 레고 완제품을 복사해놓는 격
        // 일종의 붕어빵틀 > 색상이 다르게 나온다
        // 이제 코드로 그걸 불러보자




    }
}