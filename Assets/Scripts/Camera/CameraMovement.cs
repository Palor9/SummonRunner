using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraMovement : MonoBehaviour
{
    private Rigidbody2D CameraRigitBody;

    [SerializeField]
    private Rigidbody2D PlayerRigidbody;
    private Vector2 CameraPosition;

    private void Awake()
    {
        this.CameraRigitBody = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        this.CameraRigitBody.position = PlayerRigidbody.position;
    }
}
