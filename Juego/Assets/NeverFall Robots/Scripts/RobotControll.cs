using UnityEngine;
using System;
using System.Collections;

public class RobotControll : MonoBehaviour
{
	
	private string text = "Run";
    private string textFire = "Start Fire";

    public Color teamColor = Color.red;

    public Transform gunFire1;
    public Transform gunFire2;

    public AnimationClip chasisIdle;
    public AnimationClip bodyIdle;
    public AnimationClip chasisRun;
    public AnimationClip bodyRun;
	
	public GameObject ChildToControll;
	//private float hSliderValue = 0.3f;
	
	//public Color startBackColor = Color.black;
	//public Color endBackColor = Color.white;
	
	//public Texture2D colorPicker;
    //public int ImageWidth = 100;
    //public int ImageHeight = 100;
	
	//public Camera cameraControll;
	
	// Use this for initialization
	void Start ()
	{
	    SetTeamColor(transform);
	}

    private void SetTeamColor(Transform trans)
    {
        if (trans.renderer != null)
        {
            trans.renderer.material.SetColor("_DyeColor", teamColor);
        }

        for (int i = 0; i < trans.transform.childCount; i++)
        {

            if (trans.GetChild(i).renderer != null)
            {
                trans.GetChild(i).renderer.material.SetColor("_DyeColor", teamColor);
            }

            if (trans.GetChild(i).childCount > 0)
            {
                SetTeamColor(trans.GetChild(i));
            }
        }
    }

    void Awake(){

	    if (chasisIdle)
	    {
            animation.Play(chasisIdle.name);
	    }
	    else
	    {
            animation.Stop();
	    }

		if(ChildToControll && ChildToControll.animation)
		{
            if (bodyIdle)
            {
                ChildToControll.animation.Play(bodyIdle.name);
            }
            else
            {
                ChildToControll.animation.Stop();
            }
		}

	    if (gunFire1)
	    {
            gunFire1.gameObject.SetActive(false);
	    }

	    if (gunFire2)
	    {
            gunFire2.gameObject.SetActive(false);
	    }
        
	}
	
	// Update is called once per frame
	void Update () {
	
		
	}
	
    void PlayFxBundle0()
    {
        
    }

	void OnGUI()
	{
        GUILayout.BeginArea(new Rect(10, 10, 100, 100));
		if(GUILayout.Button(text))
        {
            if (text == "Run")
			{
				text = "Idle";

                if (chasisRun != null)
                {
                    animation.Play(chasisRun.name);
                }
                else
                {
                    animation.Stop();
                }
				
				if(ChildToControll && ChildToControll.animation)
				{
                    if (bodyRun != null)
                    {
                        ChildToControll.animation.Play(bodyRun.name);
                    }
                    else
                    {
                        ChildToControll.animation.Stop();
                    }
					
				}
			}
			else
			{
				text = "Run";
                if (chasisIdle != null)
                {
                    animation.Play(chasisIdle.name);
                }
                else
                {
                    animation.Stop();
                }

				if(ChildToControll && ChildToControll.animation)
				{
                    if (bodyIdle != null)
                    {
                        ChildToControll.animation.Play(bodyIdle.name);
                    }
                    else
                    {
                        ChildToControll.animation.Stop();
                    }
                    
				}
			}
        }
        
        
        if (GUILayout.Button(textFire))
	    {
            if (textFire == "Start Fire")
            {
                textFire = "Stop Fire";

                gunFire1.gameObject.SetActive(true);
                gunFire2.gameObject.SetActive(true);
            }
            else
            {
                textFire = "Start Fire";

                gunFire1.gameObject.SetActive(false);
                gunFire2.gameObject.SetActive(false);
            }
	    }


        GUILayout.EndArea();
		
		
	
		//=======================================================================
		/*
		if (GUI.RepeatButton(new Rect(10, 100, ImageWidth, ImageHeight), colorPicker)) {

                Vector2 pickpos = Event.current.mousePosition;

                int aaa = Convert.ToInt32(pickpos.x);

                int bbb = Convert.ToInt32(pickpos.y);

                Color col = colorPicker.GetPixel(aaa,41-bbb);

 

                // "col" is the color value that Unity is returning.

                // Here you would do something with this color value, like

                // set a model's material tint value to this color to have it change

                // colors, etc, etc.

                //

                // Right now we are just printing the RGBA color values to the Console

                Debug.Log(col);

        }
        */
	}
}
