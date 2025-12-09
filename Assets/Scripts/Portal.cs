using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 충돌 > Danamic
    
}

    // Update is called once per frame
    void Update()
    {
        
    }


   // 영역 > Kinematic
    private void OnTriggerEnter2D(Collider2D collision)// Collider2D collision : other
    {
        Debug.Log("[Player] OnTriggerEnter2D");
        Player player = collision.gameObject.GetComponent<Player>();
        if(player == null)
        {
            return;
        }
        else
        {
            Debug.Log("[Player] OnTriggerEnter2D");
        }
    }
    
}
