using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : Activable
{
    public GameObject letter;
    CapsuleCollider capsuleCollider;
    MeshRenderer meshRenderer;
    public GameObject player;
    public Activable[] objectToActivateBefore;
    public Activable[] objectToActivateAfter;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public override void Interaction()
    {
        letter.SetActive(true);
        meshRenderer.enabled = false;
        for(int i = 0; i < objectToActivateBefore.Length; i++)
        {
            objectToActivateBefore[i].Interaction();
        }
    }

    private void Update()
    {
        if(letter.activeSelf)
        {
            if(Input.GetKeyUp(KeyCode.Mouse0))
            {
                letter.SetActive(false);
                meshRenderer.enabled = true;
                transform.position = player.transform.position + player.transform.forward + player.transform.up/2;
                for (int i = 0; i < objectToActivateAfter.Length; i++)
                {
                    objectToActivateAfter[i].Interaction();
                }
            }
        }
    }
}
