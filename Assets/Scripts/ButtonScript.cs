using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject objToDelete;
    [SerializeField] private AudioSource buttonSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonSound.Play();
            if(objToDelete != null)
            {
              Destroy(objToDelete);
            }
        }
    }
}
