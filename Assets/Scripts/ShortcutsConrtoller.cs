using UnityEngine;

public class ShortcutsConrtoller : MonoBehaviour
{
    public CanvasGroup menuByIKey;

    public void Start()
    {
        Toggle(false);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (menuByIKey != null)
                Toggle(menuByIKey.alpha == 0);
        }
    }

    public void Toggle(bool show)
    {
        if (menuByIKey != null)
        {
            menuByIKey.alpha = show ? 1 : 0;
            menuByIKey.interactable = show;
        }
    }
}