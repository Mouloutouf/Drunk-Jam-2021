using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    [HideInInspector]
    public bool active;
    [HideInInspector]
    public int interactionCount;

    public virtual void Interact()
    {
        interactionCount++;
    }
}
