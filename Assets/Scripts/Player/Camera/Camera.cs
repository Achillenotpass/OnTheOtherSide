using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;
    // the chacter is the capsule
    public GameObject character;
    // get the incremental value of mouse moving
    private Vector2 mouseLook;
    // smooth the mouse moving
    private Vector2 smoothV;
    // Start is called before the first frame update

    // Stop camera
    private bool m_StopSuperiorAngle = false;
    private bool m_StopInferiorAngle = false;
    private Vector2 m_ActualMouseLook;

    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ControlC();
        ControlM();
        StopMovementOnExtremeAngle();
        
    }

    void StopMovementOnExtremeAngle()
    {
        Debug.Log("aaa = " + transform.rotation.x);
        Debug.Log("bbb = " + mouseLook.y);
        //Debug.Log(transform.eulerAngles.x);
        if (mouseLook.y <= -30)
        {
            m_StopInferiorAngle = true;
        }
        if (mouseLook.y >= 40)
        {
            m_StopSuperiorAngle = true;
        }

        if (m_StopSuperiorAngle)
        {
            mouseLook.y = 40;
            m_ActualMouseLook = new Vector2(mouseLook.x, mouseLook.y);
        }
        if (m_StopInferiorAngle)
        {
            mouseLook.y = -30;
            m_ActualMouseLook = new Vector2(mouseLook.x, mouseLook.y);
        }

        if (m_StopSuperiorAngle)
        {
            if (m_ActualMouseLook.y > mouseLook.y)
                m_StopSuperiorAngle = false;
        }
        if (m_StopInferiorAngle)
        {
            if (m_ActualMouseLook.y < mouseLook.y)
                m_StopInferiorAngle = false;
        }
    }

    void ControlC()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        mouseLook += smoothV;

        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }

    void ControlM()
    {
        var md = new Vector2(Input.GetAxisRaw("RightJoystickX"), Input.GetAxisRaw("RightJoystickY"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        mouseLook += smoothV;

        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
