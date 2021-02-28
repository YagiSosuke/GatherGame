using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//テストスクリプト（実装には関係ない）
public class Stop_Penguin : MonoBehaviour
{
    [SerializeField] private Play play;
    [SerializeField] private GameObject stop_ice;
    [SerializeField] private float plus_scale;
    private bool Initialize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!play.Move)
        {
            if (Initialize)
            {
                // transformを取得
                Transform ice_Transform = stop_ice.transform;
                Vector3 ice_scale = ice_Transform.localScale;
                ice_scale.x = 1;
                ice_scale.y = 1;
                ice_scale.z = 1;
                ice_Transform.localScale = ice_scale;
                stop_ice.SetActive(true);
                Initialize = false;
            }
            if (CountDown.totalTime >= 0)
            {
                Ice_Ctrl();
            }
            
        }
        else
        {
            stop_ice.SetActive(false);
            Initialize = true;
        }
    }

    void Ice_Ctrl()
    {
        // transformを取得
        Transform ice_Transform = stop_ice.transform;
        Vector3 ice_scale = ice_Transform.localScale;
        ice_scale.x += plus_scale;
        ice_scale.y += plus_scale;
        ice_scale.z += plus_scale;
        //ice_scale.x = 1;
        //ice_scale.y = 1;
        //ice_scale.z = 1;
        ice_Transform.localScale = ice_scale;

    }
}
