using UnityEngine;
using TMPro;
using System.Collections;

public class DamagePopup : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float lifetime = 1f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Color damageColor = Color.yellow;
    [SerializeField] private Color healColor = Color.green;

    private TextMeshProUGUI textMesh;
    private bool isDamage;

    public static DamagePopup Create(Vector3 position, int amount, bool isDamage = true)
    {
        GameObject popupObj = new GameObject("DamagePopup");
        popupObj.transform.position = position;
        
        DamagePopup popup = popupObj.AddComponent<DamagePopup>();
        TextMeshProUGUI text = popupObj.AddComponent<TextMeshProUGUI>();
        
        popup.textMesh = text;
        popup.isDamage = isDamage;
        
        text.text = isDamage ? $"-{amount}" : $"+{amount}";
        text.color = isDamage ? popup.damageColor : popup.healColor;
        text.fontSize = 48;
        text.alignment = TextAlignmentOptions.Center;
        text.fontStyle = FontStyles.Bold;
        
        popup.StartCoroutine(popup.Animate());
        
        return popup;
    }

    private IEnumerator Animate()
    {
        float elapsed = 0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + Vector3.up * 2f;

        while (elapsed < lifetime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / lifetime;

            transform.position = Vector3.Lerp(startPos, endPos, t);
            
            if (textMesh != null)
            {
                Color color = textMesh.color;
                color.a = 1f - t;
                textMesh.color = color;
            }

            yield return null;
        }

        Destroy(gameObject);
    }
}
