using UnityEngine;

enum Dir // State Pattern
{
 Up,
 Down,
 Left,
 Right
}

enum State
{   
  Idle,
  Move,
  Skill
}



public class Player4 : MonoBehaviour
{
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    Dir _dir;
    State _state;

    float _distance;
    float _speed = 5f;


    //int stringToSideAttackHash = Animator.StringToHash("SideAttack");// 문자를 어떤 숫자로 변환
    //  보통은 Util 같은 곳에 넣어서 관리한다 > public으로 > 거기서 가져와서 한다 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _animator = GetComponent<Animator>(); // GameObject없이도 받아 올수 있음(대신 this) > 이걸 캐싱이라 부른다
                                            // 어딘가에 저장해두고 꺼내쓰는 방식
        // 스트라이프랜더러로 캐싱을 하자
        _spriteRenderer = GetComponent<SpriteRenderer>();
        // 회사마다 네이밍 컨벤션이 다르다 > 어디는 _ / 어디는 m_ / 
        // Generic<Type>KUV 등등 알아둬야한다.

        _animator.Play("SideAttack");    // hash : 해쉬값 > string기반으로 비교하는 것 자체가 너무 느림
                                        // 빠르게 하기 위해서 > 검색이 빨라짐
    
    }

    // Update is called once per frame
    void Update()
    {
        //키를 누르면 애니메이션이 변경되는 것
        UpdateInput();
        UpdateAnimation();

        #region 기존 방식 - 단문 작성 단점 : 꼬일 수 있음 > 모듈화 필요
        /*
         if (Input.GetKey(KeyCode.W))
        {
            //_animator.Play("UpWalk");
            _state = State.Move;
            _dir = Dir.Up;
            // 방향을 변경 > 매 프레임마다 > 배증
            moveDirection += Vector3.up;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //_animator.Play("SideWalk");
            //_spriteRenderer.flipX = true;
            _state = State.Move;
            _dir = Dir.Left;
            moveDirection += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //_animator.Play("DownWalk");
            _state = State.Move;
            _dir = Dir.Down;
            moveDirection += Vector3.down;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //_animator.Play("SideWalk"); // 반대방향으로 움직이게 하고 싶어 > flip 이 필요해
            //_spriteRenderer.flipX = false;
            _state = State.Move;
            _dir = Dir.Right;
            moveDirection += Vector3.right;
        }
        else
        {
            _state = State.Idle;
        }
        
         
         */
        #endregion

    }
    void UpdateInput()
    {

        // 자 이제 이동시켜보자
        // 1. 거리 = 속력 * 시간
        _distance = _speed * Time.deltaTime;

        // 2. 방향을 나타내려면 > Vector
        Vector3 moveDirection = Vector3.zero;

        
        if (Input.GetKey(KeyCode.W))
        {
            //_animator.Play("UpWalk");
            _state = State.Move;
            _dir = Dir.Up;
            // 방향을 변경 > 매 프레임마다 > 배증
            moveDirection += Vector3.up;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //_animator.Play("SideWalk");
            //_spriteRenderer.flipX = true;
            _state = State.Move;
            _dir = Dir.Left;
            moveDirection += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //_animator.Play("DownWalk");
            _state = State.Move;
            _dir = Dir.Down;
            moveDirection += Vector3.down;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //_animator.Play("SideWalk"); // 반대방향으로 움직이게 하고 싶어 > flip 이 필요해
            //_spriteRenderer.flipX = false;
            _state = State.Move;
            _dir = Dir.Right;
            moveDirection += Vector3.right;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            //_animator.Play("SideWalk"); // 반대방향으로 움직이게 하고 싶어 > flip 이 필요해
            //_spriteRenderer.flipX = false;
            _state = State.Skill;
            //_dir = Dir.Right;
            //moveDirection += Vector3.right;
        }
        else
        {
            _state = State.Idle;
        }
        
        // 방향 > 0,1백터 * 거리 > normalize * distance
        transform.position += moveDirection.normalized * _distance;
    }
    void UpdateAnimation() 
        // 애니메이션 로직과 기능적 로직은 반드시 따로 처리해라 > 한 군데에 다 두면 못 찾아... > 모듈화가 중요하다
    {
        if(_state == State.Idle)
        {
            //방향 > swtich > 방향 > tab tab 변수명 바꾸고 아랫방향키 누르면 자동으로 완성됨
            switch (_dir)
            {
                case Dir.Up:
                    _animator.Play("UpIdle");
                    break;
                case Dir.Down:
                    _animator.Play("DownIdle");
                    break;
                case Dir.Left:
                    _animator.Play("SideIdle");
                    _spriteRenderer.flipX = true;
                    break;
                case Dir.Right:
                    _animator.Play("SideIdle");
                    _spriteRenderer.flipX = false;
                    break;

                default:
                    break;
            }
        }
        else if (_state == State.Move)
        {
            
                //방향 > swtich > 방향 > tab tab 변수명 바꾸고 아랫방향키 누르면 자동으로 완성됨
                switch (_dir)
                {
                    case Dir.Up:
                        _animator.Play("UpWalk");
                        break;
                    case Dir.Down:
                        _animator.Play("DownWalk");
                        break;
                    case Dir.Left:
                        _animator.Play("SideWalk");
                        _spriteRenderer.flipX = true;
                        break;
                    case Dir.Right:
                        _animator.Play("SideWalk");
                        _spriteRenderer.flipX = false;
                        break;
                    default:
                        break;
                }
            

        }
        // 자 이제 공격을 해보자
        else if (_state == State.Skill)
        {
            switch (_dir)
            {
                case Dir.Up:
                    _animator.Play("UpAttack");
                    break;
                case Dir.Down:
                    _animator.Play("DownAttack");
                    break;
                case Dir.Left:
                    _animator.Play("SideAttack");
                    _spriteRenderer.flipX = true;
                    break;
                case Dir.Right:
                    _animator.Play("SideAttack");
                    _spriteRenderer.flipX = false;
                    break;

                default:
                    break;
            }

            void OnAttackEnded() 
            {
                _state = State.Idle;
            }


        }
    }
}
