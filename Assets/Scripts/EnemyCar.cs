using UnityEngine;

/// <summary> Вражеская машина: движется вниз и циклически респавнится выше в заданной полосе. </summary>
public class EnemyCar : MonoBehaviour
{
    [Header("Lane X Range")]
    [SerializeField] private Vector2 _laneXRange = new Vector2(-5f, -3f);

    [Header("Speed")]
    [SerializeField] private Vector2 _speedRangeStart = new Vector2(5f, 10f);
    [SerializeField] private Vector2 _speedRangeLoop  = new Vector2(5f, 8f);

    [Header("Respawn")]
    [SerializeField] private Vector2 _respawnYRange   = new Vector2(13f, 25f);
    [SerializeField] private float _startY = 20f;
    [SerializeField] private float _despawnY = -12f;
    [SerializeField] private float _z = -5f;

    private float _speed;

    /// <summary> Инициализирует позицию и стартовую скорость. </summary>
    private void Start()
    {
        float x = Random.Range(_laneXRange.x, _laneXRange.y);
        _speed = Random.Range(_speedRangeStart.x, _speedRangeStart.y);
        transform.position = new Vector3(x, _startY, _z);
    }

    /// <summary> Двигает машину вниз и выполняет респаун при выходе за нижнюю границу. </summary>
    private void Update()
    {
        transform.position += Vector3.down * (_speed * Time.deltaTime);

        if (transform.position.y <= _despawnY)
        {
            float x = Random.Range(_laneXRange.x, _laneXRange.y);
            float y = Random.Range(_respawnYRange.x, _respawnYRange.y);
            _speed = Random.Range(_speedRangeLoop.x, _speedRangeLoop.y);
            transform.position = new Vector3(x, y, _z);
        }
    }
}