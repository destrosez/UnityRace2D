using UnityEngine;

/// <summary> Управление машиной игрока с ограничениями по области. </summary>
public class PlayerCar : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _speed = 8f;

    [Header("Bounds")]
    [SerializeField] private float _minX = -5f;
    [SerializeField] private float _maxX = 5f;
    [SerializeField] private float _minY = -12f;
    [SerializeField] private float _maxY = 12f;

    /// <summary> Обрабатывает ввод и перемещает игрока с ограничением по границам. </summary>
    private void Update()
    {
        float dx = (Input.GetKey(KeyCode.D) ? 1f : 0f) - (Input.GetKey(KeyCode.A) ? 1f : 0f);
        float dy = (Input.GetKey(KeyCode.W) ? 1f : 0f) - (Input.GetKey(KeyCode.S) ? 1f : 0f);

        Vector3 pos = transform.position + new Vector3(dx, dy, 0f).normalized * (_speed * Time.deltaTime);
        pos.x = Mathf.Clamp(pos.x, _minX, _maxX);
        pos.y = Mathf.Clamp(pos.y, _minY, _maxY);
        transform.position = pos;
    }

    /// <summary> Фиксирует столкновение с машинами и устанавливает состояние поражения. </summary>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Car"))
        {
            GameHUD.Lose = true;
            gameObject.SetActive(false);
        }
    }
}