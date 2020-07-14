using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkInfo : NetworkBehaviour
{
    public GameObject PlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //check if this is player's own object
        if (isLocalPlayer == false)
        {
            return;
        }
        
        //command server to spawn player
        CmdSpawnUnit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Command]
    void CmdSpawnUnit() 
    {
        //give player object and send to all clients
        GameObject go = Instantiate(PlayerPrefab);
        NetworkServer.Spawn(go);
    }
}
