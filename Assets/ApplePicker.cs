using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;   // Start is called before the first frame update>
    public List<GameObject> basketList;
    public RoundRestartScript roundRestartScript;
 
    private int round = 1;
    private bool isGameOver = false;
    void Start()
    {
        basketList = new List<GameObject>();
        for(int i = 0; i < numBaskets; i++){
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
        roundRestartScript.SetRound(round);
        
    }

  public void AppleMissed()
{
    if (isGameOver) return;


    GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
    foreach (GameObject tempGO in appleArray) Destroy(tempGO);

   
    int basketIndex = basketList.Count - 1;
    GameObject basketGO = basketList[basketIndex];
    basketList.RemoveAt(basketIndex);
    Destroy(basketGO);

    
    int round = 5 - basketList.Count; 
    if (basketList.Count > 0)
    {
        roundRestartScript.SetRound(round);
    }
    else
    {
        GameOver();
    }
}

public void GameOver()
{
   
    foreach (GameObject a in GameObject.FindGameObjectsWithTag("Apple")) Destroy(a);
    foreach (GameObject b in GameObject.FindGameObjectsWithTag("Branch")) Destroy(b);

  
    foreach (GameObject basket in basketList) Destroy(basket);
    basketList.Clear();

    
    roundRestartScript.GameOver();

   
    AppleTree tree = FindObjectOfType<AppleTree>();
    if (tree != null){
     tree.CancelInvoke("DropApple");
     tree.enabled = false;
    }
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
