using UnityEngine;

public class FemaleNpc : MonoBehaviour, INpc
{
    [SerializeField] private NpcAnimationControl animationControl;

    public void GetShot()
    {
        animationControl.GetShot();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
