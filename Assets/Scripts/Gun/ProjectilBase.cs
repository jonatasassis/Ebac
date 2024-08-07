using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilBase : MonoBehaviour
{
    public float delayDestruirPorjectil;
    public int qtdDano;
    public float velProjectil;
    public float posY;
    public List<string> tagsToHit;


    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject,delayDestruirPorjectil);
        posY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward *velProjectil* Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var t in tagsToHit)
        {
            if (collision.transform.tag == t)
            {
                var damageable = collision.transform.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    Vector3 dir = collision.transform.position - transform.position;
                    dir = -dir.normalized;
                    damageable.Damage(qtdDano, dir);

                }
                break;
            }
        }
        //Destroy(gameObject);
    }
}
