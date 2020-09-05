using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloor : MonoBehaviour
{
    [SerializeField]
    private float MaxGroundAcceleration;

    private float defaultMaxGroundAcceleration;

    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            CharacterMotor charMotor = c.gameObject.GetComponent<Player>().getCharacterMotor();
            defaultMaxGroundAcceleration = charMotor.movement.maxGroundAcceleration;
            charMotor.movement.maxGroundAcceleration = this.MaxGroundAcceleration;
        }
    }

    public void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            CharacterMotor charMotor = c.gameObject.GetComponent<Player>().getCharacterMotor();
            charMotor.movement.maxGroundAcceleration = defaultMaxGroundAcceleration;
        }
    }
}
