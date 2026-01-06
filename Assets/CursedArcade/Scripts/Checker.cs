using JetBrains.Annotations;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public GameObject[] itemPrefab, enemyPrefab;
    [SerializeField] LayerMask checkerMask;
    public BasicEntity positioned;
    public Checker[] sideCheckers = new Checker[4];
    public int searched = 0;
    void Awake()
    {
        SetSideCheckers();
    }
    private void SetSideCheckers()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1, checkerMask))
        {
            sideCheckers[0] = hit.collider.GetComponent<Checker>();
        }
        else sideCheckers[0] = null;

        if (Physics.Raycast(transform.position, Vector3.right, out hit, 1, checkerMask))
        {
            sideCheckers[1] = hit.collider.GetComponent<Checker>();
        }
        else sideCheckers[1] = null;

        if (Physics.Raycast(transform.position, Vector3.back, out hit, 1, checkerMask))
        {
            sideCheckers[2] = hit.collider.GetComponent<Checker>();
        }
        else sideCheckers[2] = null;

        if (Physics.Raycast(transform.position, Vector3.left, out hit, 1, checkerMask))
        {
            sideCheckers[3] = hit.collider.GetComponent<Checker>();
        }
        else sideCheckers[3] = null;
    }

    public void SpawnObject()
    {
        float probabilidad = Random.value;
        GameObject itemToSpawn;


        if (probabilidad <= 0.2f)
        {
            itemToSpawn = itemPrefab[0];
        }
        else if (probabilidad <= 0.4f)
        {
            itemToSpawn = itemPrefab[1];
        }
        else if (probabilidad <= 0.5f)
        {
            itemToSpawn = itemPrefab[2];
        }
        else 
        {
            itemToSpawn = itemPrefab[3];
        }

        BasicEntity spawnedItem = Instantiate(itemToSpawn, transform.position, Quaternion.identity).GetComponent<BasicEntity>();
        spawnedItem.SetPositionedChecker(true);
    }
    public void SpawnEnemy()
    {
        float probabilidad = Random.value;
        GameObject enemyToSpawn;


        if (probabilidad <= 0.3f)
        {
            enemyToSpawn = enemyPrefab[0];
        }
        else
        {
            enemyToSpawn = enemyPrefab[1];
        }

        BasicEntity spawnedItem = Instantiate(enemyToSpawn, transform.position, Quaternion.identity).GetComponent<BasicEntity>();
        spawnedItem.SetPositionedChecker(true);
    }
}
