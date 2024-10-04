using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    private void Start()
    {
        ScaleBackground();
    }

    private void ScaleBackground()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        // Получаем размеры спрайта
        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        // Получаем размеры камеры
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // Устанавливаем новый размер для фона
        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
    }
}