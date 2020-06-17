using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LookAtTheMonster : MonoBehaviour
{
    [SerializeField]
    private float m_TimeLookingAtTheMonster = 0;

    public AudioSource audioSource;

    public AnimationCurve volume;

    bool on = false;

    public AnimationCurve vignetteWithTimeLookingAtTheMonster;
    public AnimationCurve chromaticAberationWithTimeLookingAtTheMonster;

    public PostProcessProfile postProcessProfile;
    private Vignette m_Vignette;
    private ChromaticAberration m_ChromaticAberation;

    void Awake()
    {
        m_Vignette = postProcessProfile.GetSetting<Vignette>();
        m_Vignette.intensity.value = 0;
        m_ChromaticAberation = postProcessProfile.GetSetting<ChromaticAberration>();
        m_ChromaticAberation.intensity.value = 0;
    }

    void Update()
    {
        if(m_TimeLookingAtTheMonster > 0)
            m_TimeLookingAtTheMonster -= 0.5f * Time.deltaTime;
        if (m_TimeLookingAtTheMonster < 0)
            m_TimeLookingAtTheMonster = 0;
        CalamityMonster();
        if (m_TimeLookingAtTheMonster > 2.5f)
            m_TimeLookingAtTheMonster = 2.5f;
        m_Vignette.intensity.value = vignetteWithTimeLookingAtTheMonster.Evaluate(m_TimeLookingAtTheMonster);
        m_ChromaticAberation.intensity.value = chromaticAberationWithTimeLookingAtTheMonster.Evaluate(m_TimeLookingAtTheMonster);
        audioSource.volume = volume.Evaluate(m_TimeLookingAtTheMonster);

        if(on)
        {
            if(m_TimeLookingAtTheMonster > 0)
            {
                audioSource.Play();
                on = false;
            }
        }

        if(m_TimeLookingAtTheMonster == 0)
        {
            audioSource.Stop();
            on = true;
        }

    }

    void CalamityMonster()
    {
        RaycastHit hitInfo;
        //Activating an activable object when pressing left-click
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 20))
        {
            //We check if the object is activable
            if (hitInfo.transform.gameObject.tag == "Monster")
            {
                m_TimeLookingAtTheMonster += 1.5f * Time.deltaTime;
            }
        }
    }
}