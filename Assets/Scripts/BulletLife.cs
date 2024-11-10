
using UnityEngine;

public class BulletLife : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
            Destroy(this.gameObject);
    }
}
