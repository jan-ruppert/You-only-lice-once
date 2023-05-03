using UnityEngine;

/// <summary>
/// Sets cursor to a given texture.
/// </summary>
public class SetCursor : MonoBehaviour
{
    /// <summary>
    /// The cursor texture.
    /// </summary>
    [SerializeField]
    private Texture2D cursorTexture;

    public Texture2D CursorTexture {
        get { return cursorTexture; }
    }

    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
