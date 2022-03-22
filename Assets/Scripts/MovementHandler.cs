using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private float speed = 0.2f;

    private void Start()
    {
        if (inputHandler == null)
        {
            Debug.LogError("Input handler не назначен");
        }
    }

    private void Update()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        if (inputHandler.IsThereTouchOnScreen())
        {
            Vector2 currDeltaPos = inputHandler.GetTouchDeltaPosition();
            currDeltaPos = currDeltaPos * speed;
            Vector3 newGravityVector = new Vector3(currDeltaPos.x, Physics.gravity.y, currDeltaPos.y);
            Physics.gravity = newGravityVector;
        }
    }

}
