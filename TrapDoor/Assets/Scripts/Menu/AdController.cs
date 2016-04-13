using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GoogleMobileAds.Api;

public class AdController : MonoBehaviour {


	private BannerView bannerView;
	private InterstitialAd interstitial;

	bool showAds;

	// Use this for initialization
	void Start () 
	{
		updateAdOptions();
		getNewAds();
		hideBannerAd();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void updateAdOptions()
	{
		if (PlayerPrefs.GetString ("ads") == "true") {
			showAds = true;
		} else if (PlayerPrefs.GetString ("ads") == "false") {
			showAds = false;
		} else { //default
			showAds = true;
		}
			
	}

	private void RequestBanner()
	{
		string adUnitId = "ca-app-pub-8558533109120159/9957174021";

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
			.AddTestDevice("96FC1D71712CF55B38F3DFBEED13E36C")  // My test device.
			.Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

	private void RequestInterstitial()
	{
		//Unity Android Ad ID
		string adUnitId = "ca-app-pub-8558533109120159/2433907220";

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
			.AddTestDevice("96FC1D71712CF55B38F3DFBEED13E36C")  // My test device.
			.Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

	public void getNewAds()
	{
		RequestBanner ();
		RequestInterstitial ();
	}

	//Interstitial Ad stuff
	public bool adIsLoaded()
	{
		return interstitial.IsLoaded ();
	}

	public void showIntAd()
	{
		interstitial.Show();
	}

	public void destroyIntAd()
	{
		interstitial.Destroy ();
	}
		
	//BannerAd Stuff
	public void hideBannerAd()
	{
		bannerView.Hide ();
	}

	public void showBannerAd()
	{
		bannerView.Show ();
	}

	public void destroyBannerAd()
	{
		bannerView.Destroy ();
	}
	
	//Ad flag stuff
	public void setAdFlag(bool flag)
	{
		if (flag) {
			showAds = true;
			PlayerPrefs.SetString("ads", "true");
		} else {
			showAds = false;
			PlayerPrefs.SetString ("ads", "false");
		}

	}
		
	public bool AdFlag()
	{
		return showAds;
	}


}
