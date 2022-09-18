using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class PlayerShoot : NetworkBehaviour
{
    public int damage;
    public float timeBetweenfire;
    float fireTimer;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(!base.IsOwner)
        return;

        if(Input.GetButton("Fire1"))
        {
            if(fireTimer<=0){
                ShootServer(damage,Camera.main.transform.position,Camera.main.transform.forward);
                fireTimer=timeBetweenfire;
            }
        }

        if(fireTimer>0)
        fireTimer-=Time.deltaTime;
    }

    [ServerRpc (RequireOwnership =false)]
    private void ShootServer(int damageToGive,Vector3 position, Vector3 direction){
          if(Physics.Raycast(position,direction,out RaycastHit hit) && hit.transform.TryGetComponent(out PlayerhealthGuide enemyHealth)){
            enemyHealth.health-=damageToGive;
          }
    }
}
