using Plugins.Dropbox;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModUIManager : MonoBehaviour
{
    [SerializeField] private Image _headerImage;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;

    public ModModel Mod { get; private set; }

    public void SetUpMod(ModModel mod)
    {
        Mod = mod;

        string path = mod.PreviewPath.Substring(1);
        StartCoroutine(LoadSprite(path));
        _title.text = mod.Title;
        _description.text = mod.Description;
    }

    private IEnumerator LoadSprite(string path)
    {
        var task = DropboxHelper.DownloadAndSaveFile(path);

        yield return new WaitUntil(() => task.IsCompleted);

        byte[] bytes = System.IO.File.ReadAllBytes(Application.persistentDataPath + "/" + path);
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);
        _headerImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}