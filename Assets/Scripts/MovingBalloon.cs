using SplineTool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBalloon : Balloon {

    [SerializeField] private FollowSpline followSpline;
	
	void Update () {
        if (followSpline.CurrPoint >= followSpline.splineWindow.spline.Length-1 && !followSpline.reverse)
        {
            followSpline.CurrPoint--;
            followSpline.StartMoving(followSpline.CurrPoint--, 0, 0, true);
        }
        else if (followSpline.CurrPoint >= followSpline.splineWindow.spline.Length - 1 && followSpline.reverse)
        {
            followSpline.CurrPoint = 1;
            followSpline.StartMoving(followSpline.CurrPoint, 0, 0, false);
        }
	}
}
