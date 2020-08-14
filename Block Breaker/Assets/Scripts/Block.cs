using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprite;

    //Cached
    Level level;
    GameStatus gameStatus;

    //State variable
    [SerializeField] int timeHit;

    void Start()
    {
        CountBreakableBlocks();

        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            timeHit++;
            int maxhits = hitSprite.Length + 1;
            if (timeHit >= maxhits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int hitSpriteIndex = timeHit - 1;
        if(hitSprite[hitSpriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[hitSpriteIndex];
        }
        else
        {
            Debug.LogError(gameObject.name + " is missing sprite");
        }
        
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        gameStatus.AddToScore();
        TriggerBlockEffect();
        Destroy(gameObject);
    }

    private void TriggerBlockEffect()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    } 
}
