using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player :ScriptableObject {


        protected GameObject go;
        protected static int id;
        protected int pid;
        protected Vector3 pos;
        float scale;
        protected bool alive = true;
        public abstract void init(float x, float y, float z, GameObject b);

    public abstract void move(Vector3 mo);
       

        public void rotate(float x, float y, float z)
        {
            go.transform.Rotate(new Vector3(x, y, z), Space.Self);
        }

        public void updateScale(float x)
        {
            go.transform.localScale *= x;
        }

        public int getId()
    {
        return pid;
    }

        public bool isAlive()
    {
        return alive;
    }
  }

