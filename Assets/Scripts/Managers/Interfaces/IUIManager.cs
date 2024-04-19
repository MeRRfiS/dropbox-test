using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIManager
{
    public GameObject LoadCanvas { get; set; }
    public void LoadCaterogies(string[] categories);
    public void LoadMods(ModModel[] mods);
}
