using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    [SerializeField] private GameObject weapon;


    void EnbleWeapon()
    {
        weapon.SetActive(true);
    }
}
