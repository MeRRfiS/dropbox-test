using Newtonsoft.Json;
using Plugins.Dropbox;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class Startup : MonoBehaviour
{
    public Slider _slider;

    private IUIManager _uiManager;

    [Inject]
    private void Constructor(IUIManager uiManager)
    {
        _uiManager = uiManager;

        StartCoroutine(GetMods());
    }

    private IEnumerator GetMods()
    {
        var task = DownloadConfig();

        yield return new WaitUntil(() => task.IsCompleted);

        string filePath = Application.persistentDataPath + "/" + "mods.json";
        using(StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            ModsResponce modsResponce = JsonConvert.DeserializeObject<ModsResponce>(json);
            _uiManager.LoadCaterogies(modsResponce.Categories);
            _uiManager.LoadMods(modsResponce.Mods);
            _uiManager.LoadCanvas.gameObject.SetActive(false);
        }
    }

    private async Task DownloadConfig()
    {
        var taskInit = DropboxHelper.Initialize();

        while(!taskInit.IsCompleted)
        {
            await Task.Yield();
        }

        var taskDownload = DropboxHelper.DownloadAndSaveFile("mods.json");

        while (!taskDownload.IsCompleted)
        {
            await Task.Yield();
        }
    }
}
