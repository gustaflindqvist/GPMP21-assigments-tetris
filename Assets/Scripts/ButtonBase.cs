using UnityEngine;
using UnityEngine.Events;

public class ButtonBase : MonoBehaviour
{
    public UnityEvent onActivate = new UnityEvent();
    public UnityEvent onDeactivate = new UnityEvent();

    public bool Activated { get; set; } = true;
    public bool CanBeUsed { get; protected set; } = false;

    public virtual void Activate()
    {
        Activated = true;
        onActivate.Invoke();
    }

    public virtual void Deactivate()
    {
        Activated = false;
        onDeactivate.Invoke();
    }

    public virtual void Toggle()
    {
        Activated = !Activated;
        if(Activated)
            Activate();
        else
            Deactivate();
    }
}