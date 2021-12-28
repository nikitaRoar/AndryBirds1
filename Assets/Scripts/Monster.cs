﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField]
    Sprite deadSprite;
    [SerializeField]
    ParticleSystem particleSystem;
    bool isDead ;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (shouldDieFromCollision(collision))
        {
           StartCoroutine( die()) ;
        }
    }
    private bool shouldDieFromCollision(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
        {
            return true;
        }
        if(collision.contacts[0].normal.y < -0.5)
        {
            return true;
        }
        return false;
    }
     IEnumerator die()
    {
        isDead = true;
        GetComponent<SpriteRenderer>().sprite = deadSprite;
        particleSystem.Play();
        yield return new WaitForSeconds(1); 
        gameObject.SetActive(false);
       
    }
}
