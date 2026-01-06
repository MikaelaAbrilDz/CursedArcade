using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image rellenoBarraVida;
    private CharacterStats playerStats;
    private float vidaMax;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        vidaMax = playerStats._life;
    }

    // Update is called once per frame
    void Update()
    {
        rellenoBarraVida.fillAmount = playerStats._life / vidaMax;
    }
}
