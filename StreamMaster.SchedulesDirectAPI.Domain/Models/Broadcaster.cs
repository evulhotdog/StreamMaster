﻿using StreamMaster.SchedulesDirectAPI.Domain.Interfaces.Models;

using System.Text.Json.Serialization;

namespace StreamMaster.SchedulesDirectAPI.Domain.Models;

public class Broadcaster : IBroadcaster
{
    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("postalcode")]
    public string Postalcode { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }
}
