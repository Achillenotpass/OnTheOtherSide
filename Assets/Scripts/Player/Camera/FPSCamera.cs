using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;
    // the chacter is the capsule
    public GameObject character;
    // get the incremental value of mouse moving
    private Vector2 m_MouseLook;
    // smooth the mouse moving
    private Vector2 m_SmoothV;
    // Start is called before the first frame update

    bool a = true;

    float b;
    float c;

    // Stop camera
    private bool m_StopSuperiorAngle = false;
    private bool m_StopInferiorAngle = false;
    private Vector2 m_ActualMouseLook;

    void Start()
    {
        //character = transform.parent.gameObject;
        //m_MouseLook = new Vector2(transform.parent.rotation.x, -transform.parent.rotation.y);
        b = transform.parent.eulerAngles.x;
        c = transform.parent.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_MouseLook);
        ControlC();
        //ControlM();
        StopMovementOnExtremeAngle();
        
    }

    void StopMovementOnExtremeAngle()
    {
        //Debug.Log(transform.eulerAngles.x);
        if (m_MouseLook.y < -60)
        {
            m_StopInferiorAngle = true;
        }
        if (m_MouseLook.y > 60f)
        {
            m_StopSuperiorAngle = true;
        }

        if(m_StopSuperiorAngle)
        {
            if (m_ActualMouseLook.y > m_MouseLook.y)
                m_StopSuperiorAngle = false;
        }
        if (m_StopInferiorAngle)
        {
            if (m_ActualMouseLook.y < m_MouseLook.y)
                m_StopInferiorAngle = false;
        }

        if (m_StopSuperiorAngle)
        {
            m_MouseLook.y = 60;
            m_ActualMouseLook = new Vector2(m_MouseLook.x, m_MouseLook.y);
        }
        if (m_StopInferiorAngle)
        {
            m_MouseLook.y = -60;
            m_ActualMouseLook = new Vector2(m_MouseLook.x, m_MouseLook.y);
        }
    }

    void ControlC()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        m_SmoothV.x = Mathf.Lerp(m_SmoothV.x, md.x, 1f / smoothing);
        m_SmoothV.y = Mathf.Lerp(m_SmoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        m_MouseLook += m_SmoothV;

        
        // vector3.right means the x-axis
        if (a == true)
        {
            Debug.Log("aaa");
            m_MouseLook = new Vector2(gameObject.transform.parent.eulerAngles.y, gameObject.transform.parent.eulerAngles.x);
            a = false;
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(-m_MouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(m_MouseLook.x, character.transform.up);
        }
    }

    void ControlM()
    {
        var md = new Vector2(Input.GetAxisRaw("RightJoystickX"), Input.GetAxisRaw("RightJoystickY"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        m_SmoothV.x = Mathf.Lerp(m_SmoothV.x, md.x, 1f / smoothing);
        m_SmoothV.y = Mathf.Lerp(m_SmoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        m_MouseLook += m_SmoothV;

        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-m_MouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(m_MouseLook.x, character.transform.up);
    }
}
