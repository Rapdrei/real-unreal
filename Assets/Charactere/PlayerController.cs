using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController :MonoBehaviour {

    //ScriptableObject
    public GameObject Gnome, pl2;
  
    LinkedList<Player> players = new LinkedList<Player>();
    

    void AddPlayerGnom(float x, float y, float z)
    {
        //print("pressed");
        Player p = ScriptableObject.CreateInstance("Gnom") as Player;
        p.init(x, y, z, Gnome);
        //print("impressed");
        p.updateScale(0.3f);
         players.AddFirst(p);
    }

    void AddPlayerTentakel(float x, float y, float z)
    {
        //print("pressed");
        Player p = ScriptableObject.CreateInstance("Tentakel") as Player;
        p.init(x,y,z,pl2);
        //print("impressed");
        p.updateScale(0.3f);
        players.AddFirst(p);
    }

    void RemovePlayer(int id)
    {
        for (int i = 0; i < players.Count; i++)
        {
            var curr = players.First;
            if (curr.Value.getId() == id)
            {
                players.Remove(curr.Value);
            }
            curr = curr.Next; 
        }
    }

    void movePlayer(int id,Vector3 move)
    {
        for (int i = 0; i < players.Count; i++)
        {
            var curr = players.First;
            if (curr.Value.getId() == id)
            {
                curr.Value.move(move);
            }
            curr = curr.Next;
        }
    }

    // Use this for initialization
    void Start () {
         AddPlayerGnom(0,0,0);
        //players.First.Value.updateScale(0.3f);
       
	}
	
	// Update is called once per frame
    // just for testing
	void Update () {
        
       
             int a = Random.Range(0, 101);

        if (Input.GetKey("y"))
        {
            
            if (a < 50) AddPlayerGnom(2.5f, 0.5f, 4);
            else AddPlayerTentakel(2.5f, 0.5f, 4);
            //Debug.Log(players.Count + "   "+players.First.ToString());
        }

         if(players.Count >0) { 
         var curr = players.First;
       // Debug.Log(curr);
       
            
                int i = 1;
            while (i <= players.Count && curr != null)
            {
              
                float x = Random.Range(-0.00f, 0.05f);
                float z = Random.Range(-0.00f, 0.05f);
                curr.Value.move(new Vector3(x, 0, z));
                if (curr.Value.isAlive())
                {
                    float rot = Random.Range(-4f, 4f);
                    curr.Value.rotate(0, Random.Range(-8, 8) * rot, 0);

                }
                else
                {
                    //TODO maybe there is a bug. i one dies all die
                    players.Remove(curr);
                }
                if(players.Count >1)
                curr = curr.Next;
                i++;
            }
         }
        //players.First.Value.move(0.1f, 0.2f, 0.3f);
	}
}
