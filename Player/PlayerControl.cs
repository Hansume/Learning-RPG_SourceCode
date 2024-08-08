using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public LayerMask groundMask;

    public Interactables focus;
    PlayerMotor motor;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButton(1) && Physics.Raycast(ray, out hit, 100, groundMask))
        {
            motor.MoveToPoint(hit.point);
            RemoveFocus();
        }

        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit, 100))
        {
            Interactables interactables = hit.collider.GetComponent<Interactables>();
            if (interactables != null)
            {
                SetFocus(interactables);
            }
        }
    }

    void SetFocus(Interactables newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDeFocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDeFocused();
        }
        focus = null;
        motor.UnfollowTarget();
    }
}
