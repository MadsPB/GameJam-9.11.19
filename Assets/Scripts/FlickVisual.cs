using UnityEngine;
using System.Collections.Generic;

public class FlickVisual : MonoBehaviour
{
    public InputManager InputManager;
    public List<GameObject> ArrowPieces;

    private Vector2 _startingPointerPosition;

    public void Start()
    {
        InputManager.PointerDown += HandlePointerDown;
        InputManager.PointerUp += HandlePointerUp;
        InputManager.Drag += HandleDrag;
    }

    private void HandlePointerDown(Vector2 position)
    {
        _startingPointerPosition = position;
        Show();
    }

    private void HandlePointerUp(Vector2 position)
    {
        _startingPointerPosition = Vector2.zero;
        Hide();
    }

    private void HandleDrag(Vector2 position)
    {
        var yScale = position - _startingPointerPosition;
        var differenceVector = position - _startingPointerPosition;
        var angle = Mathf.Atan2(differenceVector.y, differenceVector.x);

        var localScale = transform.localScale;
        localScale = new Vector3(localScale.x, yScale.magnitude * 0.01f, localScale.z);
        transform.localScale = localScale;
        transform.localRotation = Quaternion.Euler(0f, 0f, angle * 180f);
    }

    private void Show()
    {
        foreach (var arrowPiece in ArrowPieces)
        {
            arrowPiece.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (var arrowPiece in ArrowPieces)
        {
            arrowPiece.SetActive(false);
        }
    }
}