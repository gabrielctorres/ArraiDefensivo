using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform Target;
    public AnimationCurve curve;
    [SerializeField] private float duration = 1;
    [SerializeField] private float maxHeightY = 3;


    public void Start()
    {
        StartCoroutine(Curve(transform.position, Target.position));
    }
    public IEnumerator Curve(Vector3 start, Vector3 end)
    {
        var timePast = 0f;
        while (timePast < duration)
        {
            timePast += Time.deltaTime;

            var linearTime = timePast / duration;
            var heightTime = curve.Evaluate(linearTime);
            var height = Mathf.Lerp(0, maxHeightY, heightTime);
            transform.position = Vector3.Lerp(start, end, linearTime) + new Vector3(0, height, 0); //adding values on y axis
            yield return null;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemie>() != null)
        {
            collision.GetComponent<Enemie>().TakeDamage(10f);
            Destroy(this.gameObject);
        }
    }
}
