using UnityEngine;

public class BallDelete : MonoBehaviour
{
    [SerializeField]
    private float destroyHeight;
    void Update()
    {
        if (transform.position.y < destroyHeight)
        {
            Destroy(gameObject);
        }
    }
}
