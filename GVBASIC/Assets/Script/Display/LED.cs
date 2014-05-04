﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// LED screen emulator 
/// </summary>
public class LED : MonoBehaviour 
{
    public SpriteRenderer m_spriteRender;
    public Color m_whiteColor;

    protected Texture2D m_texture;
    protected Dictionary<int,ASCII> m_asciis;

	// Use this for initialization
	void Start () 
    {
        m_texture = m_spriteRender.sprite.texture;

        initASCIITable();
        
        CleanScreen();
	}
	
	// Update is called once per frame
	void Update () 
    {
        m_texture.Apply();
	}

    /// <summary>
    /// set pixel 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="set"></param>
    public void SetPixel( int x, int y, bool set )
    {
        m_texture.SetPixel(x, y, set ? Color.black : m_whiteColor);
    }

    /// <summary>
    /// clean screen 
    /// </summary>
    public void CleanScreen()
    {
        //m_texture.SetPixels(0, 0, 160, 80, new Color[] { m_whiteColor });

        for (int i = 0; i < 5; i++ )
        {
            for( int j = 0; j < 20; j++ )
            {
                m_texture.SetPixels( j*8, i*16, 8, 16, m_asciis[i*20+j].m_color );
            }
        }
    }

    /// <summary>
    /// initial the ASCII table 
    /// </summary>
    protected void initASCIITable()
    {
        m_asciis = new Dictionary<int, ASCII>();

        // initial the ASCII code 
        for( int i = 0; i < 128; i++ )
        {
            ASCII ascii = new ASCII(i, m_whiteColor, Color.black);
            m_asciis[i] = ascii;
        }
    }

}
