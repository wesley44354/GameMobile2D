using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text livesText;
    [SerializeField] private DeathOnDamage deathOnDamage;


    private void Update()
    {
        livesText.text = deathOnDamage.Lives.ToString();

    }
}
