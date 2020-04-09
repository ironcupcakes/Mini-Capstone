﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public enum EnemyType
    {
        none, chaser, sentry, droid, factory, spawn
    }

    abstract public void TakeDamage(float damage);
    abstract public bool IsAlive();
    public abstract void Die();
    public bool AutoAimable = true;
    public bool DieOnCollision = true;
    public float Damage;
    public int ProtectionPriority;
    public GunnerController.EnemyType Type;
    public Material EnemyMaterial;

    public float DamageTransparencyRatio = 0.75f;
    public float TimeDamaged = 0.3f;
    private Renderer eRenderer;
    private Color originalColor;
    private Color damagedColor;
    protected EnemyType type;
    protected float timeDamaged = 0.0f;
    protected int gameID;

    protected virtual void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (GunnerController.Instance.PlayerProjectileMask == (GunnerController.Instance.PlayerProjectileMask | (1 << other.gameObject.layer)))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
            return;
        }

        PlayerBehaviour pBehaviour = other.gameObject.GetComponent<PlayerBehaviour>();
        if (pBehaviour)
        {
            pBehaviour.TakeDamage(Damage);
            Die();
        }
    }

    protected bool DamageEffectLoop(bool turnOn)
    {
        if (turnOn)
        {
            ShowDamageEffect();
        }

        timeDamaged += Time.deltaTime;

        if(timeDamaged > TimeDamaged)
        {
            ResetDamageEffect();
            return false;
        }


        return true;
    }


    protected void SetEnemyType()
    {
        Type = GunnerController.Instance.GetRandomizedEnemyType();
        EnemyMaterial = GunnerController.Instance.EnemyMaterialMap[Type];
    }

    protected void ShowDamageEffect()
    {
        if (!eRenderer)
        {
            eRenderer = GetComponent<Renderer>();
            originalColor = eRenderer.material.color;
            damagedColor = new Color(originalColor.r * 0.2f, originalColor.g * 0.2f, originalColor.b * 0.2f, originalColor.a * 0.2f);
        }
       
        eRenderer.material.color = damagedColor;
        timeDamaged = 0.0f;
    }

    protected void ResetDamageEffect() 
    {
        if (!eRenderer)
        {
            eRenderer = GetComponent<Renderer>();
            originalColor = eRenderer.material.color;
            damagedColor = new Color(originalColor.r * 0.2f, originalColor.g * 0.2f, originalColor.b * 0.2f, originalColor.a * 0.2f);
        }

        eRenderer.material.color = originalColor;
    }
}
