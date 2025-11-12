using UnityEngine;

public class BasicEntity : MonoBehaviour
{
    [SerializeField] protected LayerMask checkerMask;

    protected Checker CurrentChecker()
    {
        return Physics.OverlapBox(transform.position, Vector3.one / 10f, Quaternion.identity, checkerMask)[0].GetComponent<Checker>();
    }
    protected void SetPositionedChecker(bool enabling)
    {
        CurrentChecker().positioned = this;
        if (!enabling) CurrentChecker().positioned = null;
    }
}
