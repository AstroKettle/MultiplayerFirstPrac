using UnityEngine;

public class PlayerMovementWithForce1 : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения
    private Rigidbody rb; // Ссылка на Rigidbody
    private float rotationSpeed = 80f;
    private Vector3 BoomVector = new Vector3(3.0f, 3.0f, 3.0f);
    [SerializeField] private GameObject Camera;

    public float countOfPoints = 20f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody
    }

    public void Update()
    {
        MoveArrows();
        
        if (transform.localScale == BoomVector) {
            Destroy(this.gameObject);
        }
    }

    private void MoveArrows()
    {
        // Получаем ввод от клавиатуры
        float moveHorizontal = Input.GetAxis("ArrowsHoriz"); // A и D
        float moveVertical = Input.GetAxis("ArrowsVert"); // W и S

        // Создаем вектор движения
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
    // private ScoreToWin(float countOfPoints) {
    //     if (this.countOfPoints == countOfPoints) {
    //         Destroy.Object();
            
    //     }
    // }
}