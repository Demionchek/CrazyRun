using UnityEngine;

public class RotatorToDegreeses : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float yDegreses1;
    [SerializeField] private float yDegreses2;
    private bool goRight;

    private void Start()
    {
        goRight = true;
    }

    void Update()
    {
        if (goRight)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, yDegreses2, 0), speed * Time.deltaTime);
        }
        else if (!goRight)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, yDegreses1, 0), speed * Time.deltaTime);
        }

        if (transform.rotation.y >= 0.65f)
        {
            goRight = false;
        }
        else if (transform.rotation.y <= 0.01f)
        {
            goRight = true;
        }
    }
}
