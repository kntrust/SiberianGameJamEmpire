using Live2D.Cubism.Framework.Motion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubismMotionLoopPlayer : MonoBehaviour
{
    // AnimationClip to be played in a loop
    [SerializeField]
    public AnimationClip Animation;
    private CubismMotionController _motionController;
    private void Start()
    {
        _motionController = GetComponent<CubismMotionController>();


        // Loop playback of motions
        _motionController.PlayAnimation(Animation);
    }
}