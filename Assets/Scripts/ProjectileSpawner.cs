using System.Collections;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab; // Префаб снаряда
    public float spawnInterval = 1f; // Интервал генерации в секундах
    public float projectileSpeed = 10f; // Скорость снаряда

    private void Start()
    {
        // Запускаем корутину для генерации снарядов
        StartCoroutine(SpawnProjectiles());
    }

    private IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            // Генерируем снаряд
            SpawnProjectile();

            // Ждем заданный интервал перед следующим выстрелом
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnProjectile()
    {
        // Создаем снаряд на позиции спавнера
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Получаем Rigidbody для управления движением
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Направляем снаряд в сторону, в которую смотрит спавнер
            rb.velocity = transform.forward * projectileSpeed;
        }
    }
}

