using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject ArmsGO;
    private RaycastToMouse _raycastToMouse;
    private void Start()
    {
        _raycastToMouse = ArmsGO.GetComponent<RaycastToMouse>();
    }

    
    void Update()
    {
        if (_raycastToMouse.pointedObject != Vector3.zero)
        {
            // Calcula la dirección hacia el objetivo
            //Vector3 direccion = (_raycastToMouse.pointedObject.transform.position - transform.position).normalized;
            
            // También puedes utilizar Rotate() para girar el objeto gradualmente
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direccion), Time.deltaTime * 3f);
            
            // Utiliza LookAt() para hacer que el objeto apunte hacia el objetivo
            //Vector3 pointed = new Vector3(_raycastToMouse.pointedObject.transform.position.x,
             //   (transform.position + _raycastToMouse.raycastDirection).y, _raycastToMouse.pointedObject.transform.position.z);
            //transform.LookAt(_raycastToMouse.pointedObject.transform);
            
            //pointed = new Vector3((transform.position + _raycastToMouse.raycastDirection).x,
            //    _raycastToMouse.pointedObject.transform.position.y, _raycastToMouse.pointedObject.transform.position.z);
            
            //transform.LookAt(pointed);
            
            transform.LookAt(_raycastToMouse.pointedObject);
        }
        else
        {
            transform.LookAt(transform.position + _raycastToMouse.raycastDirection);
        }
        
        

        
    }
}
