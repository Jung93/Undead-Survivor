using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;


    private void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);


                break;
            default:

                break;
        }
    }

    public void Init() {
        switch (id) {
            case 0:
                speed = -150;
                PlaceWeapon();


                break;
            default:
                
                break;
        }
    }


    void PlaceWeapon() {
        for (int i = 0; i < count; i++) {
            Transform bulltet = GameManager.instance.pool.Get(prefabId).transform;
            bulltet.parent = transform;

            Vector3 rotVec = Vector3.forward * 360 * i / count;
            bulltet.Rotate(rotVec);
            bulltet.Translate(bulltet.up * 1.5f, Space.World);

            bulltet.GetComponent<Bullet>().Init(damage, -1);

        }
    }
}
