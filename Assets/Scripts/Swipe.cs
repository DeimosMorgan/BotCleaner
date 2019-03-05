using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool _tap;
    private bool _swipeLeft;
    private bool _swipeRight;
    private bool _isDraging = false;
    private Vector2 _startTouch, _swipeDelta;

    public Vector2 SwipeDelta { get { return _swipeDelta; } }

    public bool Tap { get { return _tap; } }
    public bool IsDraging { get { return _isDraging; } }
    public bool SwipeLeft { get { return _swipeLeft; } }
    public bool SwipeRight { get { return _swipeRight; } }

    private void Update()
    {
        _tap = _swipeLeft = _swipeRight = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            _tap = true;
            _isDraging = true;
            _startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ResetData();
        }
        #endregion
        #region Mobile Inputs
        if(Input.touches.Length != 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                _tap = true;
                _isDraging = true;
                _startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                _isDraging = false;
                ResetData();
            }
        }
        #endregion

        _swipeDelta = Vector2.zero;

        if (_isDraging)
        {
            if(Input.touches.Length > 0)
            {
                _swipeDelta = Input.touches[0].position - _startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                _swipeDelta = (Vector2)Input.mousePosition - _startTouch;
            }
        }

        if(_swipeDelta.magnitude > 50)
        {
            float x = _swipeDelta.x;
            float y = _swipeDelta.y;

            if(Mathf.Abs(y) < Mathf.Abs(x))
            {
                if(x < 0)
                {
                    _swipeLeft = true;
                }
                else
                {
                    _swipeRight = true;
                }
            }

            //ResetData();
        }
    }

    private void ResetData()
    {
        _startTouch = _swipeDelta = Vector2.zero;
        _isDraging = false;
    }
}
