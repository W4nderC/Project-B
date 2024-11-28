using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpd;
    
    private bool isShot;
    
    private void Awake()
    {
        
    }

    private void Start() 
    {
        GameInput.Instance.OnShotPerformed += GameInput_OnShotPerformed;
        GameInput.Instance.OnShotCanceled += GameInput_OnShotCanceled;
    }

    private void GameInput_OnShotCanceled(object sender, EventArgs e)
    {
        isShot = false;
        print("isShot: "+isShot);
    }

    private void GameInput_OnShotPerformed(object sender, EventArgs e)
    {
        isShot = true;
        print("isShot: "+isShot);

    }

    private void Update() 
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0);
        // float moveDistance = moveSpd * Time.deltaTime;

        transform.position += moveDir * moveSpd * Time.deltaTime;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if(isShot) 
        {
            if(other.transform.gameObject.TryGetComponent<INpc>(out INpc npc)) 
            {
                npc.GetShot();
            }            
        }

    }

}
