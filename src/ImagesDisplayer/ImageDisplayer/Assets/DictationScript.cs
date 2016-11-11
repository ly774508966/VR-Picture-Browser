﻿using UnityEngine;
using System.Collections;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class DictationScript : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    

    void Start()
    {
        string[] tags = new string[(Assets.PicturesManager.pictureDictionary).Keys.Count];
        (Assets.PicturesManager.pictureDictionary).Keys.CopyTo(tags, 0);
        for (int i = 0; i < tags.Length; i++)
        {
            keywords.Add(tags[i], () =>
            {
                testCalled();
            });
        }
        keywordRecognizer = new KeywordRecognizer(tags);
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizedOnPhraseRecognized;
        keywordRecognizer.Start();
        print(keywordRecognizer.IsRunning);
    }

    void KeywordRecognizedOnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        print("recognized " + args.text);
        Main.scriptInstance.onTagRecognised(args.text);
    }

    void testCalled()
    {
        print("it works!");
    }
}