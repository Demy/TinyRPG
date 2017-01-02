using UnityEngine;

public class ShortcutsConrtoller : MonoBehaviour
{
    public CanvasGroup menuByIKey;
    public GameObject mainCharacter;

    private MovementController movable;

    public void Start() {
        movable = mainCharacter.GetComponent<MovementController>();

        ToggleMenu(false, menuByIKey);
    }

    public void Update() {
        ToggleMenues();
        MoveCharacterWASD();
    }

    public void ToggleMenues() {
        if (Input.GetKeyUp(KeyCode.I))
        {
            ToggleMenu(menuByIKey.alpha == 0, menuByIKey);
        }
    }

    public void ToggleMenu(bool show, CanvasGroup menu) {
        if (menu != null)
        {
            menu.alpha = show ? 1 : 0;
            menu.interactable = show;
        }
    }

    public void MoveCharacterWASD() {
        Vector3 speed = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKeyUp(KeyCode.A))
        {
            speed.x -= 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            speed.x += 1;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            speed.z += 1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            speed.z -= 1;
        }
        if (speed.x != 0 || speed.z != 0)
        {
            movable.Move(speed);
        }
        RotateCharacterToCursor();
        // TODO: Rotate camera vertially
        // TODO: Make rotation initial point dependant
    }

    public void RotateCharacterToCursor()
    {
        mainCharacter.transform.rotation =
            Quaternion.Euler(new Vector3(0f, GetRotationByMouse(mainCharacter.transform), 0f));
    }

    public void RotateCameraToCursor()
    {
        Camera.main.transform.rotation =
            Quaternion.Euler(new Vector3(
                    Camera.main.transform.rotation.x,
                    Camera.main.transform.rotation.y,
                    Camera.main.transform.rotation.z
            ));
    }

    public float GetRotationByMouse(Transform transform)
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        return AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}