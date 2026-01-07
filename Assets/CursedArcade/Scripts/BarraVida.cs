using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image rellenoBarraVida;
    private CharacterStats charStats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charStats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        rellenoBarraVida.fillAmount = (float)charStats._life / (float)charStats._lifeMax;
    }
}
