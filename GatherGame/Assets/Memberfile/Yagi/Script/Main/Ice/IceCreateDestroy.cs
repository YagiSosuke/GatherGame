using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*氷のオブジェクト生成時*/
/*他のオブジェクトと衝突していたら削除する*/

public class IceCreateDestroy : MonoBehaviour
{
    [SerializeField] bool ColCheckF = false;

    GameObject IceBreak;
    GameObject IceBreakCreateObject;

    IceBreakCreate createScript;
    // Start is called before the first frame update
    void Start()
    {
        IceBreak = this.gameObject.transform.parent.gameObject;
        IceBreakCreateObject = IceBreak.transform.parent.gameObject;
        createScript = IceBreakCreateObject.GetComponent<IceBreakCreate>();

        StartCoroutine(CreateComplate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (!ColCheckF)
        {
            if(col.name != "Plane" && col.name != "FallCollider")
            {
                createScript.IceBreakCount--;
                Destroy(IceBreak.gameObject);
            }
        }
    }

    private IEnumerator CreateComplate()
    {
        yield return 0;
        ColCheckF = true;
    }
}
