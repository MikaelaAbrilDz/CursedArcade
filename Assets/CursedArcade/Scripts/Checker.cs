using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] LayerMask checkerMask;
    BasicEntity positioned;
    public Checker[] sideCheckers = new Checker[4];
    void Awake()
    {
        SetSideChckers();
    }
    private void SetSideChckers()
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
}
