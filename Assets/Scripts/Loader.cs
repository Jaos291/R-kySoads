using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        GameScene,
        LoadingScene,
        Gameplay,
        Menu,
        StageSelect,
    }

    private static Action onLoaderCallback;

    public static void Load(string scene)
    {
        //Set Loader
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene);
        };

        //Load Scene

        SceneManager.LoadScene(Scene.LoadingScene.ToString());

    }

    public static void LoaderCallback() {
        //Triggered after the first update
        //Execute loader callback
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}


