using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIManager
{
    [Header("Transforms")]
    [SerializeField] private Transform _modsList;
    [SerializeField] private Transform _categoriesList;

    [Header("Prefabs")]
    [SerializeField] private GameObject _modsInfo;
    [SerializeField] private GameObject _categoryButton;

    [field: Header("Canvases")]
    [field: SerializeField] public GameObject LoadCanvas { get; set; }


    public void LoadCaterogies(string[] categories)
    {
        foreach (string category in categories)
        {
            CategoryUIManager categoryManager = Instantiate(_categoryButton, _categoriesList)
                                                .GetComponent<CategoryUIManager>();
            categoryManager.SetUpButton(category);
        }
    }

    public void LoadMods(ModModel[] mods)
    {
        foreach (ModModel mod in mods)
        {
            ModUIManager modManager = Instantiate(_modsInfo, _modsList)
                                      .GetComponent<ModUIManager>();
            modManager.SetUpMod(mod);
        }
    }
}
