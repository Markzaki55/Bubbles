using UnityEngine;

public class InputManager : MonoBehaviour
{
    Camera cam;
    private void Start()
    {
        UI_InputHandler.Instance.AssignInputEvent("Touch", OnTouchPress, Inputs.InputState.Pressed);
        cam = Camera.main;
    }
    public void OnTouchPress()
    {
        foreach (var touch in Input.touches)
        {
            Ray touchRay = cam.ScreenPointToRay(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(touchRay.origin, touchRay.direction);

            if (hit.collider != null)
            {
                Ipopable PopObject = hit.collider.GetComponent<Ipopable>();
                if (PopObject != null)
                {
                    PopObject.pop();
                }
            }
        }
    }

}
