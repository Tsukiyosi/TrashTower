using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PackController : MonoBehaviour
{
	[SerializeField] Image packImage;
	[SerializeField] TMP_Text packName;
	[SerializeField] TMP_Text packPrice;
	[SerializeField] Button priceBtn;
	private bool isSelected = false;
	private PackConfig packConf;

	public void GetConf(PackConfig config)
	{
		packConf = config;
		packImage.sprite = packConf.contentImage;
		packName.text = packConf.packName;
		
	}
    private void Update()
    {
		if (PlayerManager.GetPackId.Exists(x => x == packConf.id))
		{
			priceBtn.image.color = new Color(110 / 256f, 87 / 256f, 238 / 256f);
			packPrice.text = "Selected";
			isSelected = true;
		}
		else if (PlayerManager.GetBoughtPackId.Exists(x => x == packConf.id))
		{
			priceBtn.image.color = new Color(84 / 256f, 85 / 256f, 89 / 256f);
			packPrice.text = "Bought";
			isSelected = false;
		}
		else
		{
			priceBtn.image.color = new Color(82 / 256f, 188 / 256f, 81 / 256f);
			packPrice.text = packConf.packPrice.ToString();
			isSelected = false;
		}
	}

    public void SetPack()
    {
		if (isSelected)
        {

			PlayerManager.DeletePackId = packConf.id;
			packPrice.text = packConf.packPrice.ToString();
			isSelected = false;

		}
		else
        {
            if(PlayerManager.GetBoughtPackId.Exists(x => x == packConf.id))
            {
				packPrice.text = "Selected";
				PlayerManager.AddPackId = packConf.id;
				isSelected = true;
			}
            else
            {
				if(PlayerManager.Money >= packConf.packPrice)
                {
					PlayerManager.Money -= packConf.packPrice;
					PlayerManager.BuyPackId = packConf.id;
					packPrice.text = "Selected";
					PlayerManager.AddPackId = packConf.id;
					isSelected = true;
				}
              
            }
        }
    }
}
