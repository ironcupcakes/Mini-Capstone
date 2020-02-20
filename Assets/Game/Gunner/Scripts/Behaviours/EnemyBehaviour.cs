﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    abstract public void TakeDamage(float damage);
    abstract public bool IsAlive();
    public bool AutoAimable = true;
}

