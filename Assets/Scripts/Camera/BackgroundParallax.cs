using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{

    private float startPosition;
    [SerializeField] private new GameObject camera;
    [SerializeField] private float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        float dist = (camera.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);
    }
}
