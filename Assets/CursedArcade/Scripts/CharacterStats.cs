using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //STATS BÁSICAS DE CUALQUIER PERSONAJE
    [SerializeField] private string characterName = "Enemigo";
    [SerializeField] private int life = 100;
    [SerializeField] private int lifeMax = 100;
    [SerializeField] private int speed = 1;
    [SerializeField] private int attack = 1;
    
    
    public int speedBase, attackBase, lifeMaxBase;

    [Header("Damage Popup")]
    [SerializeField] private GameObject damagePopupPrefab;


    public string CharacterName => characterName;
    public int Life => life;
    public int LifeMax => lifeMax;
    public int Speed => speed;
    public int Attack => attack;




    private void Start()
    {
        _speed = speedBase;
        _attack = attackBase;
        _lifeMax = lifeMaxBase;
    }

    public int _life
    {
        get
        {
            return life;
        }

        set
        {
            //Mostrar popup de daño recibido mientras q sea mayor q 0
            int damage = Mathf.Max(0, life - value);
            if (damage > 0)
            { 
                ShowDamagePopup(damage);
            }

            life = Mathf.Clamp(value, 0, lifeMax);


            if (life == 0)
            {
                //MORIR
                FindAnyObjectByType<TurnManager>().turnList.Remove(GetComponent<CharacterOnGround>());
                Destroy(gameObject);
            }

        }

    }

    private void ShowDamagePopup(int damage)
    {
        if (damagePopupPrefab == null) return;

        //he puesto una posicion al azar, tendría q comprobar que está bien o si se cambiaría.
        Vector3 spawnPos = transform.position + Vector3.up * 1.5f;

        GameObject popupObj = Instantiate(damagePopupPrefab, spawnPos, Quaternion.identity);

        DamagePopup popup = popupObj.GetComponent<DamagePopup>();
        if (popup != null)
        {
            popup.Setup(damage);
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
