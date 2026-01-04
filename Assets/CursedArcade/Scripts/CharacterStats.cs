using UnityEngine;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    //STATS BÁSICAS DE CUALQUIER PERSONAJE
    [SerializeField] private int life = 100;
    [SerializeField] private int lifeMax = 100;
    private int speed = 1;
    private int attack = 1;
    public int speedBase, attackBase;
    private void Start()
    {
        _speed = speedBase;
        _attack = attackBase;
    }

    public int _life
    {
        get
        {
            return life;
        }

        set
        {
            life = Mathf.Clamp(value, 0, lifeMax);

            if (life == 0)
            {
                //MORIR
                FindAnyObjectByType<TurnManager>().turnList.Remove(GetComponent<CharacterOnGround>());
                Destroy(gameObject);
            }

        }

    }

    public int _lifeMax
    {
        get
        {
            return lifeMax;
        }

        set
        {
            lifeMax = value;
        }
    }

    public int _attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public int _speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
}
