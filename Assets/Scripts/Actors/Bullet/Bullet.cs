using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeTimeController))]
public class Bullet : MonoBehaviour, IBullet, IMovable
{
    private LifeTimeController _lifeTimeController;

    
    public float LifeTime => _lifeTime;
    [SerializeField] private float _lifeTime = 3f;

    public float MovementSpeed => _MovementSpeed;
    [SerializeField] private float _MovementSpeed = 15f;

    public int bulletDamage = 10;
    
    void Start()
    {
        _lifeTimeController = GetComponent<LifeTimeController>();
        _lifeTimeController.SetLifeTime(LifeTime);
        _MovementSpeed = _MovementSpeed * (Input.GetAxis("Horizontal")>0?(1+Input.GetAxis("Horizontal")):(-1*(-1+Input.GetAxis("Horizontal")))  );
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _MovementSpeed );
        
        if(_lifeTimeController.IsLifeTimeOver())
            Destroy(this.gameObject);
    }

    
    void OndDestroy()
    {
        Debug.Log("Bullet destroyed");
    }


    public void Move(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * _MovementSpeed);
    }
    
    public void Travel()
    {
        Move(Vector3.right);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                EventQueueManager.instance.AddEvent(new CmdApplyDamage(damageable, bulletDamage));
            }
            Destroy(this.gameObject);
        }
        
    }
   
}
