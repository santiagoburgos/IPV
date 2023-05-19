using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Weapons
{
    HAND = 0,
    PISTOL = 1,
    DOUBLEPISTOL = 2
}

public enum Hand
{
    LEFT = 0,
    RIGHT = 1
}

public class Character : MonoBehaviour
{

    [SerializeField] private List<Weapon> _availableWeaponsRight;
    [SerializeField] private Weapon _currentWeaponRight;
    private Weapons _currentWeaponsRight;
    
    [SerializeField] private List<Weapon> _availableWeaponsLeft;
    [SerializeField] private Weapon _currentWeaponLeft;
    private Weapons _currentWeaponsLeft;
    
    public int jumps = 2;
    public int _currentJumps = 0;
    private float _jumpTimer = 0;
    
    public bool isGrounded;
    public bool topHit;

    public int bullets = 5;
    public int bulletsBagSize = 20;

    //Raycasts are used for the custom gravity and jumps
    public float XRight;
    public float XLeft;
    public float YStart;
    public float YDistance;
    public float YStart2;
    public float YDistance2;
    

    private MovementController _movementController;
    
    //COMMANDS
    private CmdMovement _cmdMoveRight;

    private CmdAttack _cmdAttackLeft;
    private CmdAttack _cmdAttackRight;
    void Start() 
    {
        EquipWeapon(Weapons.HAND, Hand.RIGHT);
        _currentWeaponsRight = Weapons.HAND;
        EquipWeapon(Weapons.HAND, Hand.LEFT);
        _currentWeaponsLeft = Weapons.HAND;
        
        _movementController = GetComponent<MovementController>();
        //_cmdMoveRight = new CmdMovement(_movementController, transform.right);

        //_cmdAttackLeft = new CmdAttack(_currentWeaponLeft);
        //_cmdAttackRight = new CmdAttack(_currentWeaponRight);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && _jumpTimer > 1f)
        {
            _currentJumps = 0;
            _jumpTimer = 0;
        }
        else
        {
            _jumpTimer += Time.deltaTime;
        }
        
        if ((Input.GetAxis("Horizontal") > 0) || (Input.GetAxis("Horizontal") < 0))
        {
            EventQueueManager.instance.AddEvent(new CmdMovement(_movementController, transform.right * Input.GetAxis("Horizontal")));
        }


        if (Input.GetKey(KeyCode.R) && Input.GetMouseButtonDown(0))
        {
            EventQueueManager.instance.AddEvent(new CmdReload(_currentWeaponLeft));
        }
        else if (Input.GetMouseButtonDown(0))
        {
            EventQueueManager.instance.AddEvent(_cmdAttackLeft);
            
        }
        
        
        if (Input.GetKey(KeyCode.R) && Input.GetMouseButtonDown(1))
        {
            EventQueueManager.instance.AddEvent(new CmdReload(_currentWeaponRight));
        }
        else if (Input.GetMouseButtonDown(1))
        {
            
            EventQueueManager.instance.AddEvent(_cmdAttackRight);
        }
        
        //TODO
        GetComponent<GravityController>().Move(Vector3.down);

        if (Input.GetButtonDown("Jump") && _currentJumps < jumps)
        {
            GetComponent<JumpController>().Move(Vector3.up);
            _currentJumps += 1;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EquipNextWeapon(_currentWeaponsRight,Hand.RIGHT);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            EquipNextWeapon(_currentWeaponsLeft,Hand.LEFT);
        }
        
    }
    
    
    private void FixedUpdate()
    {
        RaycastHit hitXRight;
        Vector3 _directionXRight = new Vector3(transform.position.x +XRight, transform.position.y + YStart, transform.position.z );
        RaycastHit hitXLeft;
        Vector3 _directionXLeft = new Vector3(transform.position.x +XLeft, transform.position.y + YStart, transform.position.z );
        
        Debug.DrawRay(_directionXRight, -Vector3.up.normalized *YDistance, Color.red);
        Debug.DrawRay(_directionXLeft, -Vector3.up.normalized *YDistance, Color.red);
        
        if (Physics.Raycast(_directionXRight, Vector3.down, out hitXRight, YDistance,-5,QueryTriggerInteraction.Ignore))
        {
            isGrounded = true;
            
            //fixed position
            float distance = YDistance - hitXRight.distance;
            if (distance >= 0.1)
            {

                transform.Translate(Vector3.up * 3f * Time.deltaTime);
                //transform.position = new Vector3(transform.position.x, transform.position.y + (YDistance - hitXRight.distance), transform.position.z);
            }
        }
        else if(Physics.Raycast(_directionXLeft, Vector3.down, out hitXLeft, YDistance,-5,QueryTriggerInteraction.Ignore))
        {
            isGrounded = true;
            
            //fixed position
            float distance = YDistance - hitXLeft.distance;
            if (distance >= 0.1)
            {
                transform.Translate(Vector3.up * 3f * Time.deltaTime);
                //transform.position = new Vector3(transform.position.x, transform.position.y + (YDistance - hitXLeft.distance), transform.position.z);
            }
        }
        else
        {
            isGrounded = false;
        }

        //TOP HIT
        Vector3 _directionXRight2 = new Vector3(transform.position.x +XRight, transform.position.y + YStart2, transform.position.z );
        Vector3 _directionXLeft2 = new Vector3(transform.position.x +XLeft, transform.position.y + YStart2, transform.position.z );
        
        Debug.DrawRay(_directionXRight2, Vector3.up.normalized *YDistance2, Color.magenta);
        Debug.DrawRay(_directionXLeft2, Vector3.up.normalized *YDistance2, Color.magenta);
        if (Physics.Raycast(_directionXRight2, Vector3.up, out hitXRight, YDistance2,-5,QueryTriggerInteraction.Ignore))
        {
            topHit = true;
            
            //fixed position
            float distance = YDistance - hitXRight.distance;
            if (distance >= 0.1)
            {
                transform.Translate(Vector3.down * 3f * Time.deltaTime);
                //transform.position = new Vector3(transform.position.x, transform.position.y + (YDistance - hitXRight.distance), transform.position.z);
            }
        }
        else if(Physics.Raycast(_directionXLeft2, Vector3.up, out hitXLeft, YDistance2,-5,QueryTriggerInteraction.Ignore))
        {
            topHit = true;
            
            //fixed position
            float distance = YDistance - hitXLeft.distance;
            if (distance >= 0.1)
            {
                transform.Translate(Vector3.down * 3f * Time.deltaTime);
                //transform.position = new Vector3(transform.position.x, transform.position.y + (YDistance - hitXLeft.distance), transform.position.z);
            }
        }
        else
        {
            topHit = false;
        }
    }
    
    
    
    
    

    private void EquipWeapon(Weapons weapons, Hand hand)
    {
        if (hand == Hand.RIGHT)
        {
            foreach (Weapon weapon in _availableWeaponsRight)
            {
                weapon.gameObject.SetActive(false);
            }

            _currentWeaponRight = _availableWeaponsRight[(int)weapons];
            _currentWeaponRight.gameObject.SetActive(true);
            
            _cmdAttackRight = new CmdAttack(_currentWeaponRight);
            
        }
        else if(hand == Hand.LEFT)
        {
            foreach (Weapon weapon in _availableWeaponsLeft)
            {
                weapon.gameObject.SetActive(false);
            }

            _currentWeaponLeft = _availableWeaponsLeft[(int)weapons];
            _currentWeaponLeft.gameObject.SetActive(true);
            
            _cmdAttackLeft = new CmdAttack(_currentWeaponLeft);
        }
        
        //TODO if is Gun check isRealoding and use event for UI, also use event un Gun class itself
    }
    
    private void EquipNextWeapon(Weapons weapons, Hand hand)
    {
        Weapons equip = Weapons.HAND;

        switch (weapons)
        {
            case Weapons.HAND:
                equip = Weapons.PISTOL;
                break;
            case Weapons.PISTOL:
                equip = Weapons.DOUBLEPISTOL;
                break;
            case Weapons.DOUBLEPISTOL:
                equip = Weapons.HAND;
                break;
        }
        
        if (hand == Hand.RIGHT)
        {
            _currentWeaponsRight = equip;
        }
        else if(hand == Hand.LEFT)
        {
            _currentWeaponsLeft = equip;
        }
        
        EquipWeapon(equip, hand);
    }
    
   
}
