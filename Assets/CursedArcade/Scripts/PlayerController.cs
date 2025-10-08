using UnityEngine;

public class PlayerController : BasicEntity
{
    void Update()
    {
        Checker checker = Physics.OverlapBox(transform.position, Vector3.one / 10f, Quaternion.identity, checkerMask)[0].GetComponent<Checker>();

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = checker.sideCheckers[0].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = checker.sideCheckers[1].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = checker.sideCheckers[2].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = checker.sideCheckers[3].transform.position;
        }
    }
}
