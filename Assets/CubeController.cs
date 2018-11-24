﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    public float rotateSpeed = 1f;

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);

	}

    //StartCoroutine(lerpRotation(Quaternion.Euler(0, 0, 90), 1f));
    public IEnumerator lerpRotation(Quaternion aimRot, float lerpSpeed)
    {

        var initalRot = transform.rotation;
        var ratio = 0f;

        while (ratio < 1)
        {
            ratio += Time.deltaTime * lerpSpeed;
            var newRot = Quaternion.Slerp(initalRot, aimRot, ratio);
            transform.rotation = newRot;

            print("lerping");
            print(newRot);

            yield return null;
        }

        transform.rotation = aimRot;

        yield break;
    }

}
