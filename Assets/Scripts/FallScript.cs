using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallScript : MonoBehaviour
{
    [SerializeField] private Transform spawn;
    [SerializeField] private AudioSource holeSound;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            transform.position = spawn.position;
            rb.velocity = new Vector3(0,0,0);
            holeSound.Play();
        }
    }
}
