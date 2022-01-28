
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] InputAction movement;
    void Start()
    {

    }
    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
    [SerializeField] float controlSpeed = 35f;
    void Update()
    {
        float horizontalThrow = movement.ReadValue<Vector2>().x;
        float verticalThrow = movement.ReadValue<Vector2>().y;

        float horizontalOffSet = horizontalThrow * Time.deltaTime * controlSpeed;
        float verticalOffSet = verticalThrow * Time.deltaTime * controlSpeed;

        float newXPosition = transform.localPosition.x + horizontalOffSet;
        float newYPosition = transform.localPosition.y + verticalOffSet;
        transform.localPosition = new Vector3(newXPosition, newYPosition, transform.localPosition.z);
    }
}
