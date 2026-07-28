using UnityEngine;

public class GameCursorController : MonoBehaviour
{
    [SerializeField] private Texture2D gameCursor;
    private Vector2 hotspot = Vector2.zero;

    private void Awake()
    {
        Cursor.SetCursor(gameCursor, hotspot, CursorMode.Auto);
    }

    private void OnDestroy()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
