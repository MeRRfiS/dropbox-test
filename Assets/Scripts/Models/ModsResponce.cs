using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModsResponce
{
    [JsonProperty("mods")]
    public ModModel[] Mods { get; set; }

    [JsonProperty("categories")]
    public string[] Categories { get; set; }
}
