using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Sprite sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameObject[] go = new GameObject[7];
        //Color[] colorName = new Color[7] { Color.red, Color.orange, Color.yellow, Color.green, Color.blue, Color.navyBlue, Color.purple };
        //for (int i = 0; i < go.Length; ++i)
        //{

        //        go[i] = new GameObject();
        //        go[i].name = $"Square {++i}";

        //    SpriteRenderer spriteRenderer = go[i].AddComponent<SpriteRenderer>();
        //    //SpriteRenderer spriteRenderer = spriteRenderer1;
        //        go[i].GetComponent<SpriteRenderer>().sprite = sprite;

        //        go[i].GetComponent<SpriteRenderer>().color = colorName[i];

        //        Transform tr = go[i].transform;
        //        tr.position = new Vector3(i - 3, 0, 0);


        //}
        GameObject[] go1 = new GameObject[7];

        go1[0] = new GameObject();
        go1[1] = new GameObject();
        go1[2] = new GameObject();
        go1[3] = new GameObject();
        go1[4] = new GameObject();
        go1[5] = new GameObject();
        go1[6] = new GameObject();
        

        go1[0].name = $"Square {1}";
        go1[1].name = $"Square {2}";
        go1[2].name = $"Square {3}";
        go1[3].name = $"Square {4}";
        go1[4].name = $"Square {5}";
        go1[5].name = $"Square {6}";
        go1[6].name = $"Square {7}";


        SpriteRenderer sr1 = go1[0].AddComponent<SpriteRenderer>();
        SpriteRenderer sr2 = go1[1].AddComponent<SpriteRenderer>();
        SpriteRenderer sr3 = go1[2].AddComponent<SpriteRenderer>();
        SpriteRenderer sr4 = go1[3].AddComponent<SpriteRenderer>();
        SpriteRenderer sr5 = go1[4].AddComponent<SpriteRenderer>();
        SpriteRenderer sr6 = go1[5].AddComponent<SpriteRenderer>();
        SpriteRenderer sr7 = go1[6].AddComponent<SpriteRenderer>();

        go1[0].GetComponent<SpriteRenderer>().sprite = sprite;
        go1[1].GetComponent<SpriteRenderer>().sprite = sprite;
        go1[2].GetComponent<SpriteRenderer>().sprite = sprite;
        go1[3].GetComponent<SpriteRenderer>().sprite = sprite;
        go1[4].GetComponent<SpriteRenderer>().sprite = sprite;
        go1[5].GetComponent<SpriteRenderer>().sprite = sprite;
        go1[6].GetComponent<SpriteRenderer>().sprite = sprite;

        go1[0].GetComponent<SpriteRenderer>().color = Color.red;
        go1[1].GetComponent<SpriteRenderer>().color = Color.orange;
        go1[2].GetComponent<SpriteRenderer>().color = Color.yellow;
        go1[3].GetComponent<SpriteRenderer>().color = Color.green;
        go1[4].GetComponent<SpriteRenderer>().color = Color.blue;
        go1[5].GetComponent<SpriteRenderer>().color = Color.navyBlue;
        go1[6].GetComponent<SpriteRenderer>().color = Color.purple;


        Transform tr1 = go1[0].transform;
        Transform tr2 = go1[1].transform;
        Transform tr3 = go1[2].transform;
        Transform tr4 = go1[3].transform;
        Transform tr5 = go1[4].transform;
        Transform tr6 = go1[5].transform;
        Transform tr7 = go1[6].transform;

        tr1.position = new Vector3(-3, 0, 0);
        tr2.position = new Vector3(-2, 0, 0);
        tr3.position = new Vector3(-1, 0, 0);
        tr4.position = new Vector3(0, 0, 0);
        tr5.position = new Vector3(1, 0, 0);
        tr6.position = new Vector3(2, 0, 0);
        tr7.position = new Vector3(3, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
