using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*時間経過で足跡を消す*/

public class PrintDelee : MonoBehaviour
{
    [SerializeField] SpriteRenderer foot;

    float time = 0;
    //残る時間
    [SerializeField] float interval = 3.0f;
    //消えていく時間
    [SerializeField] float deleteTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time < interval)
        {
            foot.color = new Color(1, 1, 1, 0.75f);
        }
        else if(time < deleteTime)
        {
            foot.color = Color.Lerp(new Color(1, 1, 1, 0.75f), new Color(1, 1, 1, 0), time-interval);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
