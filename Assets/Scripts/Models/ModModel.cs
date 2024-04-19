using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModModel
{
    [JsonProperty("category")]
    public string Category { get; set; }

    [JsonProperty("preview_path")]
    public string PreviewPath { get; set; }

    [JsonProperty("file_path")]
    public string FilePath { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
} 
