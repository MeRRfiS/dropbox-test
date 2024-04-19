using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoInstaller
{
    [field: Header("Managers")]
    [field: SerializeField] public UIManager UIManager { get; private set; }

    public override void InstallBindings()
    {
        BindUIManager();
    }

    private void BindUIManager()
    {
        Container.Bind<IUIManager>()
                      .FromInstance(UIManager)
                      .AsSingle();
    }
}
