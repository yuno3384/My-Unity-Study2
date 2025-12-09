using UnityEngine;

public class Player3 : MonoBehaviour
{
    //GameObject go;
    public float distance;
    public float speed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        distance = speed * Time.deltaTime;
        Vector3 direction = Vector3.zero;
        // 위로 X 아래로 X
        /*
         W: 위 (Up) / 앞 (Forward)
         A: 왼쪽 (Left)
         S: 아래 (Down) / 뒤 (Backward)
         D: 오른쪽 (Right)
         */
        if (Input.GetKey(KeyCode.W))
        {
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        transform.position += direction.normalized * distance;
    }
}
