using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*落とし穴を自動生成する*/

public class IceBreakCreate : MonoBehaviour
{
    [SerializeField] int IceBreakMAX;
    public int IceBreakCount = 0;

    [SerializeField] GameObject IceBreak;
    GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while(IceBreakCount < IceBreakMAX)
        {
            instance = Instantiate(IceBreak);
            instance.transform.position = new Vector3(Random.Range(-400, 400), 0, Random.Range(-400, 400));
            instance.transform.Rotate(0, Random.Range(0,360), 0);
            instance.transform.SetParent(this.gameObject.transform);

            IceBreakCount++;
        }
    }
}
