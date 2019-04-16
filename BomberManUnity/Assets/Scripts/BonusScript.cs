using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    [SerializeField]
    ScriptableBonus bonus;
    [SerializeField]
    ScriptableBonus[] prefabsBonus;
    SpriteRenderer sprt;
    
    // Start is called before the first frame update
    void Start()
    {
        prefabsBonus = Resources.LoadAll<ScriptableBonus>("Scriptables");
        bonus = prefabsBonus[Random.Range(0, prefabsBonus.Length)];
        sprt = GetComponent<SpriteRenderer>();
        sprt.sprite = bonus.sprt;
        Invoke("Desapear", 5f);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            var ob = collision.gameObject.GetComponent<DropBomb>();
            var typ = typeof(DropBomb);
            var f = typ.GetField(bonus.variableAffected);
            var val = f.GetValue(ob);
            f.SetValue(ob, (int)val + bonus.value);

            Desapear();
        }
    }

    private void Desapear()
    {
        Destroy(gameObject);
    }
}
