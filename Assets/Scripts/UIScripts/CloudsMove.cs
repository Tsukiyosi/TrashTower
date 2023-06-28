using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CloudsMove : MonoBehaviour
{
	[SerializeField] public List<GameObject> cloudsImages;
    private float movePoseX = 7;
    private float speed = 5f;

    private void Awake()
    {
        Sequence s1 = DOTween.Sequence();
        Sequence s2 = DOTween.Sequence();
        Sequence s3 = DOTween.Sequence();

        s1.Append(cloudsImages[0].transform.DOMoveX(movePoseX, speed).SetEase(Ease.Linear));
        s1.Append(cloudsImages[0].transform.DOMoveX(-movePoseX, 0).SetEase(Ease.Linear));
        s1.Append(cloudsImages[0].transform.DOMoveX(0, speed).SetEase(Ease.Linear));

        s2.Append(cloudsImages[1].transform.DOMoveX(0, speed).SetEase(Ease.Linear));
        s2.Append(cloudsImages[1].transform.DOMoveX(movePoseX, speed).SetEase(Ease.Linear));
        s2.Append(cloudsImages[1].transform.DOMoveX(-movePoseX, 0)).SetEase(Ease.Linear);

        s3.Append(cloudsImages[2].transform.DOMoveX(-movePoseX, 0)).SetEase(Ease.Linear);
        s3.Append(cloudsImages[2].transform.DOMoveX(0, speed).SetEase(Ease.Linear));
        s3.Append(cloudsImages[2].transform.DOMoveX(movePoseX, speed)).SetEase(Ease.Linear);


        s1.SetLoops(-1);
        s2.SetLoops(-1);
        s3.SetLoops(-1);
    }
     
}
