﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}