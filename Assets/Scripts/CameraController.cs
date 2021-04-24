using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     float shootDelay = 0.75f;
     float shootElapsedTime = 0;

    // Update is called once per frame
    void Update()
    {

        if(GameManager.Instance.startGame)
        {
            shootElapsedTime += Time.deltaTime;
            if (Input.GetMouseButtonDown(0) && shootElapsedTime > shootDelay)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    if (hit.collider.tag == "Player")
                    {
                        shootElapsedTime = 0;
                        hit.transform.gameObject.GetComponent<Shooter>().Shoot();

                    }
                }
            }
        }
        
    }
}
