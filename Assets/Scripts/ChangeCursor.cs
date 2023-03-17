using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    //[SerializeField]
    //Texture2D cursorImage;


    //// Start is called before the first frame update
    //void Start()
    //{
    //    Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.ForceSoftware);
    //}

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
