using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dislabe : MonoBehaviour
{
    [SerializeField] private GameObject weapon;


    void DislabeWeapon()
    {
        weapon.SetActive(false);
    }
}
