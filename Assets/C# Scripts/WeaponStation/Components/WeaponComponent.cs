using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponComponent {
    protected bool activeComponent = false;

    public virtual void Initialize() {}
    public virtual void ActivateComponent() { activeComponent = true; }
    public virtual void DeactivateComponent() { activeComponent = false; }
    public virtual void ToggleComponent()
    {
        if (!activeComponent)
        {
            ActivateComponent();
        }
        else
        {
            DeactivateComponent();
        }
    }
    public virtual void Update() {}
}
