using UnityEngine;
using UnityEngine.EventSystems;
using Debug = System.Diagnostics.Debug;

public class BallShot : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private float power;

    [SerializeField]
    // 発射間のインターバルタイム
    private float intervalTime;
    
    private float _time = 0;

    private const int MouseLeft = 0;

    void Update()
    {
        _time -= Time.deltaTime;
        if (_time < 0)
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                return;
            }

            if (Input.GetMouseButtonDown(MouseLeft))
            {
                var ball = Instantiate(ballPrefab);
                ball.transform.position = transform.position;
                Debug.Assert(Camera.main != null, "Camera.main != null");
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var target = ray.direction;
                ball.GetComponent<Rigidbody>().velocity = target * power;
                _time = intervalTime;
            }
        }
    }
}
