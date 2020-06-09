 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : Activable
{
    private AudioSource m_AudioSource;
    public GameObject letter;
    CapsuleCollider capsuleCollider;
    MeshRenderer meshRenderer;
    public GameObject player;
    public Activable[] objectToActivateBefore;
    public Activable[] objectToActivateAfter;
    public bool alreadyActivated = false;

    //To disable
    private Player m_Player;
    private Bending m_Bending;
    private Crouching m_Crouching;
    private FPSCamera m_FPSCamera;
    private Interaction m_Interaction;


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        m_AudioSource = GetComponent<AudioSource>();

        m_Player = FindObjectOfType<Player>();
        m_Bending = FindObjectOfType<Bending > ();
        m_Crouching = FindObjectOfType<Crouching>();
        m_FPSCamera = FindObjectOfType<FPSCamera>();
        m_Interaction = FindObjectOfType<Interaction>();
    }

    public override void Interaction()
    {
        m_Player.enabled = false;
        m_Bending.enabled = false;
        m_Crouching.enabled = false;
        m_FPSCamera.enabled = false;
        m_Interaction.enabled = false;

        m_AudioSource.Play();
        letter.SetActive(true);
        meshRenderer.enabled = false;
        if (!alreadyActivated)
        {
            for (int i = 0; i < objectToActivateBefore.Length; i++)
            {
                objectToActivateBefore[i].Interaction();
            }
        }
    }

    private void Update()
    {
        if(letter.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                m_Player.enabled = true;
                m_Bending.enabled = true;
                m_Crouching.enabled = true;
                m_FPSCamera.enabled = true;
                m_Interaction.enabled = true;

                letter.SetActive(false);
                meshRenderer.enabled = true;
                transform.position = player.transform.position + player.transform.forward + player.transform.up/2;
                if (!alreadyActivated)
                {
                    alreadyActivated = true;
                    for (int i = 0; i < objectToActivateAfter.Length; i++)
                    {
                        objectToActivateAfter[i].Interaction();
                    }
                }
            }
        }
    }
}
