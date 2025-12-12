using System.Collections;
using UnityEngine;

public enum Step
{
    Step1_CountDown, 
    Step2_Wait, 
    Step3_WaitSpace
}



public class Main12 : MonoBehaviour
{
    // 코루틴 : C#기능을 유니니티에서 보다 편히쓰기 위해서 만든 기능 > 인공지능에서 주로 쓰임
    // 코루틴 : 함수를 실행할 건데 그 함수의 상태를 우리가 중간에 저장할 수 있는 함수
    // 예) 튜토리얼
    //예) 카운트다운 > 1초마다 출력, 숫자가 점점 줄어들어야 > 끝나면 3초간 대기, 3초 후 스페이스 바를 눌렀을때 축하합니다.
    /// <summary>
    // 코루틴은 구현법이 어려우므로... 일단 따라해보자
    /// </summary>

    //예) 카운트다운 > 1초마다 출력,
    //숫자가 점점 줄어들어야 >
    //끝나면 3초간 대기,
    //3초 후 스페이스 바를 눌렀을때 축하합니다. 
    Step _step = Step.Step1_CountDown;
    Coroutine _coroutine;
   //void TestFunc() 
   // {
   //     for(int i =0; i < 10_000_000_000_000; i++)
   //         //숫자 중간에 언더바 : 자릿수 표시로 > 컴파일 오류가 안난다
   //     {   // 매 천번 마다 나와야 한다.
   //         // 일감을 천개씩 분류한다
   //         // 그냥 함수에는 저장 기능이 없으니까 > 엄청 고생하게 된다.
   //         continue;   
   //     }
   // }
   // 보통 코루틴의 컨벤션은 Co로 시작한다.
    IEnumerator CoTutorial()
    {
        for(int count = 5; count > 0; count--)
        {
            Debug.Log(count);
            yield return new WaitForSeconds(1); //> 양보후 리턴 1초동안 대기하겠다.
                                                // Delay execution by the amount of time in seconds.
        }
        Debug.Log("3초간 대기 시작");
        yield return new WaitForSeconds(3);
        Debug.Log("3초간 대기 종료");
        //return; > 리턴으로 불가
        //yield return null; //> 양보후 리턴

        while (true)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    break;
            //}
            //yield return null; //양보하라고!!
            //트랜스폼.포지션 += 이동관련 변수

            yield return null;


        }
        Debug.Log("축하합니다. 튜토리얼이 완료되었습니다.");
    }
    // >> 코드가 훨씬 직관적으로 바뀌었다.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(CoTutorial()); 코루틴이 시작하는 거
        _coroutine = StartCoroutine(CoTutorial());// 코루틴의 현재 상태를 저장
        StopCoroutine(_coroutine); //코루틴을 중간에 꺼버리는 것 > 경우에 따라 필요
    }
    int _counter = 5;
    float _sumTime = 1f;
    // Update is called once per frame
    void Update() // 업데이트 자주 쓰지 마라 : 코드가 많아지면 성능이 저하된다. > 일부만 반복이면 코루틴으로
    {
        //if (_step == Step.Step1_CountDown)
        //{
        //    _sumTime += Time.deltaTime;
        //    if (_sumTime >= 1)
        //    {
        //        Debug.Log(_counter);

        //        _counter--;

        //        _sumTime = 0;

        //        if (_counter == 0)
        //        {
        //            _step = Step.Step2_Wait;
        //        }
        //    }
        //}
        //else if (_step == Step.Step2_Wait)
        //    // 3초간 기다려달라
        //{
        //    _sumTime += Time.deltaTime;

        //    if (_sumTime >= 3)
        //    {
                
        //       _step = Step.Step3_WaitSpace;
                
        //    }
        //}
        //else if (_step == Step.Step3_WaitSpace)
        //// 3초간 기다려달라
        //{
        //    _sumTime += Time.deltaTime;

        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {

        //        Debug.Log("축하합니다. 튜토리얼이 완료되었습니다.");

        //    }
        //}
        // 이렇게 만들면 팀장님께 아름다운 사랑을 받을 거야... > 굉장히 색다르게 바라볼 거고..
        // >> 코루틴으로 해결해보자
    }
}
