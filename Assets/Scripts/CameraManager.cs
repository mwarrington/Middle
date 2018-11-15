using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera TheCamera;
    public SpriteRenderer FadeMask;

    public Transform CameraLocationForLeft,
                     CameraLocationForRight,
                     CameraLocationForUp,
                     CameraLocationForForward;

    public bool NoFade;

    private Vector3 _movePosition;
    private bool _fadingIn,
                 _fadingOut;

    private void Update()
    {
        if(_fadingIn)
        {
            FadeIn();
        }
        else if(_fadingOut)
        {
            FadeOut();
        }

        //temp
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeView(LookDirections.UP);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeView(LookDirections.FORWARD);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeView(LookDirections.LEFT);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeView(LookDirections.RIGHT);
        }
    }

    public void ChangeView(LookDirections directionToLook)
    {
        if (NoFade)
        {
            switch (directionToLook)
            {
                case LookDirections.UP:
                    MoveCamera(CameraLocationForUp.position);
                    break;
                case LookDirections.FORWARD:
                    MoveCamera(CameraLocationForForward.position);
                    break;
                case LookDirections.LEFT:
                    MoveCamera(CameraLocationForLeft.position);
                    break;
                case LookDirections.RIGHT:
                    MoveCamera(CameraLocationForRight.position);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (directionToLook)
            {
                case LookDirections.UP:
                    _movePosition = CameraLocationForUp.position;
                    _fadingOut = true;
                    break;
                case LookDirections.FORWARD:
                    _movePosition = CameraLocationForForward.position;
                    _fadingOut = true;
                    break;
                case LookDirections.LEFT:
                    _movePosition = CameraLocationForLeft.position;
                    _fadingOut = true;
                    break;
                case LookDirections.RIGHT:
                    _movePosition = CameraLocationForRight.position;
                    _fadingOut = true;
                    break;
                default:
                    break;
            }
        }
    }

    private void FadeIn()
    {
        if (FadeMask.color.a > .02f)
            FadeMask.color = new Color(FadeMask.color.r, FadeMask.color.g, FadeMask.color.b, FadeMask.color.a - 0.05f);
        else
        {
            _fadingIn = false;
            FadeMask.color = new Color(FadeMask.color.r, FadeMask.color.g, FadeMask.color.b, 0);
        }
    }

    private void FadeOut()
    {
        if (FadeMask.color.a < .98f)
            FadeMask.color = new Color(FadeMask.color.r, FadeMask.color.g, FadeMask.color.b, FadeMask.color.a + 0.05f);
        else
        {
            _fadingOut = false;
            FadeMask.color = new Color(FadeMask.color.r, FadeMask.color.g, FadeMask.color.b, 1);
            MoveCamera(_movePosition);
            _fadingIn = true;
        }
    }

    private void MoveCamera(Vector3 moveLocation)
    {
        TheCamera.transform.position = new Vector3(moveLocation.x, moveLocation.y, TheCamera.transform.position.z);
    }
}