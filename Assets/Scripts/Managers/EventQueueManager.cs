using System;
using System.Collections.Generic;
using UnityEngine;

public class EventQueueManager : MonoBehaviour
{
    static public EventQueueManager instance;

    public List<Icommand> Events => _events;
    private List<Icommand> _events = new List<Icommand>();
    private void Awake()
    {
        if(instance != null) Destroy(this);
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        // Dar vuelta a la lista
        _events.Reverse();
        
        for (int i = _events.Count-1; i >= 0; i--)
        {
            _events[i].Execute();
            _events.RemoveAt(i);
        }
    }

    public void AddEvent(Icommand command) => _events.Add(command);
}
