﻿using Newtonsoft.Json;

namespace Transmission.Net.Api;

/// <summary>
/// Base class for request/response
/// </summary>
public abstract class CommunicateBase
{
    /// <summary>
    /// Data
    /// </summary>
    [JsonProperty("arguments")]
    public Dictionary<string, object>? Arguments;

    /// <summary>
    /// Number (id)
    /// </summary>
    [JsonProperty("tag")]
    public int? Tag;

    /// <summary>
    /// Convert to JSON string
    /// </summary>
    /// <returns></returns>
    public virtual string? ToJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    /// <summary>
    /// Deserialize to class
    /// </summary>
    /// <returns></returns>
    public T? Deserialize<T>()
    {
        var argumentsString = JsonConvert.SerializeObject(Arguments);
        return JsonConvert.DeserializeObject<T>(argumentsString);
    }
}
