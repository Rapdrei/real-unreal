using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gnom :Player {

    override
    public void init(float x, float y, float z, GameObject b)
    {
        pos = new Vector3(x, y, z);
        pid = id++;
        go = Instantiate<GameObject>(b, new Vector3(x, y, z), Quaternion.identity);
        go.transform.Translate(pos, Space.World);

    }

    override
          public void move(Vector3 mo)
    {
       
        pos += mo;
        // Debug.Log((pos.x -5) + "  " + (pos.z -8));
        go.transform.Translate(mo , Space.Self);

        if ((go.transform.position.x -5 < -3.22 || go.transform.position.x -5 > 2.62) 
            || (go.transform.position.z-8 < -3.58 || go.transform.position.z -8> 4.031))
        {

            Destroy(go, 0.0f);
            Debug.Log(go.transform.position.x + "  " + go.transform.position.y + "   " + go.transform.position.z + "  " + pid);
            alive = false;
        }
    }

}
