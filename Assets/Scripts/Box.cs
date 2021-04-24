using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public ShooterColor Targetcolor;
    public ShooterColor currentColor;
    public GameObject boxParticle;
    private bool colored = false;
    public AudioSource audioSource;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {

            currentColor = other.GetComponent<Ball>().color;
            transform.gameObject.GetComponent<MeshRenderer>().material.color = other.GetComponent<Ball>().ballColor;
            boxParticle.SetActive(true);
            audioSource.Play();
            StartCoroutine(DisableEffect());
            if (currentColor == Targetcolor)
            {
                if (!colored)
                {
                    GameManager.Instance.trueColor++;
                }                   
                colored = true;
            }
            else
            {
                if (colored)
                {
                    GameManager.Instance.trueColor--;
                }
                colored = false;
            }

        }
    }

    IEnumerator DisableEffect()
    {
        yield return new WaitForSeconds(0.5f);
        boxParticle.SetActive(false);
    }
}
