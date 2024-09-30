using UnityEngine;

public class PlayerMovementWithForce : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения
    private Rigidbody rb; // Ссылка на Rigidbody
    private float rotationSpeed = 80f;
    [SerializeField] private GameObject Camera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // Получаем ввод от клавиатуры
        float moveHorizontal = Input.GetAxis("Horizontal"); // A и D
        float moveVertical = Input.GetAxis("Vertical"); // W и S

         Vector3 direction = new Vector3(Camera.transform.forward.x,0,Camera.transform.forward.z) * moveVertical;
        Debug.Log(moveVertical);
        
        Debug.Log(Camera.transform.forward);

        transform.rotation *= Quaternion.Euler(0f, rotationSpeed*moveHorizontal*Time.deltaTime, 0f);

        // Применяем силу к Rigidbody
        rb.AddForce(direction * moveSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        
        Destroy(other.gameObject);
    }
}