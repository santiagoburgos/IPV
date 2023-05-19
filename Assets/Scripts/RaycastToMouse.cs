using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastToMouse : MonoBehaviour
{
    
    public Camera pointerCamera;
    public float distance = 10f;

    public Vector3 pointedObject;
    public Vector3 raycastDirection;

    public GameObject model;

    private float XFoot = 0.3f;
    private bool XFootBool = false;
    
    // Update is called once per frame
    void Update()
    {
        // 1. Obtener la posición del mouse en la pantalla
        Vector3 mousePosition = Input.mousePosition;
        
        // 2. Convertir la posición del mouse en la pantalla en una posición en el mundo
        Vector3 mouseWorldPosition = pointerCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - pointerCamera.transform.position.z));
        
        Vector3 direction = mouseWorldPosition - transform.position;

        //
        raycastDirection = direction;

        if (direction.normalized.y < 0 && direction.normalized.x > -XFoot && direction.normalized.x < XFoot)
            XFootBool = true;
        else
        {
            XFootBool = false;
        }
        
        //rotate player
        if (direction.x < 0)
        {
            Vector3 newRotation = model.transform.rotation.eulerAngles;
            newRotation.y = 180f;
            model.transform.rotation = Quaternion.Euler(newRotation);
        }
        else
        {
            Vector3 newRotation = model.transform.rotation.eulerAngles;
            newRotation.y = 0f;
            model.transform.rotation = Quaternion.Euler(newRotation);
        }
        
        
        Debug.DrawRay(transform.position, direction.normalized * distance, Color.green);

        if (Physics.Raycast(transform.position, direction.normalized, out RaycastHit hit,distance,-5,QueryTriggerInteraction.Ignore))
        {

            IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();
            if (damageable != null && !hit.collider.gameObject.CompareTag("Bullet") && !XFootBool)
            {
                pointedObject = hit.point;
            }else
                pointedObject = Vector3.zero;

        }
        else
        {
            pointedObject = Vector3.zero;
        }

    }
}
