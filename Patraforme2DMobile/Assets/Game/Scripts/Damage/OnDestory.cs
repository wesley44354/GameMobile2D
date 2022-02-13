using UnityEngine;

public class OnDestory : MonoBehaviour
{

    GameObject parent;

    private void Awake()
    {
        parent = transform.parent.gameObject;
    }


    void Death()
    {
        Destroy(parent);
    }
}
