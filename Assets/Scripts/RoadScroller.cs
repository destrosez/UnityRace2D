using UnityEngine;

/// <summary> Скроллит дорожное полотно по Y и зацикливает его. </summary>
public class RoadScroller : MonoBehaviour
{
    [Header("Scroll")]
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _resetAtY = -10f;
    [SerializeField] private Vector3 _resetTo = new Vector3(0f, 10f, 0f);

    /// <summary> Перемещает дорогу и выполняет перенос назад при достижении порога. </summary>
    private void Update()
    {
        transform.position += Vector3.down * (_speed * Time.deltaTime);
        if (transform.position.y <= _resetAtY) transform.position = _resetTo;
    }
}