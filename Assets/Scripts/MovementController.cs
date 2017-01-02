using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float characterSpeed = 0.1f;

    public void Move(float difX, float difZ)
    {
        Move(new Vector3(difX, 0, difZ));
    }
    public void Move(Vector3 speed)
    {
        Vector3 translateTo = Vector3.ClampMagnitude(speed, characterSpeed);
        Debug.Log("Move to:");
        Debug.Log(speed);
        Debug.Log("Result:");
        Debug.Log(translateTo);
        gameObject.transform.Translate(translateTo);
    }

    public void Jump()
    {
    }
}
