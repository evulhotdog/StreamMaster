﻿using System.Text.Json.Serialization;

namespace StreamMasterApplication.Common.Interfaces;

public interface IStreamHandler : IDisposable
{
    /// <summary>
    /// true if there is an existing client registered; otherwise, false.
    /// </summary>
    bool HasClient(Guid clientId);

    /// <summary>
    /// Gets the ring buffer used for storing video chunks.
    /// </summary>
    ICircularRingBuffer RingBuffer { get; }

    /// <summary>
    /// Gets or sets the M3U file ID.
    /// </summary>
    int M3UFileId { get; set; }

    /// <summary>
    /// Gets or sets the URL of the stream.
    /// </summary>
    string StreamUrl { get; }

    string VideoStreamId { get; }

    /// <summary>
    /// Gets or sets the cancellation token source for video streaming.
    /// </summary>
    [JsonIgnore]
    CancellationTokenSource VideoStreamingCancellationToken { get; set; }

    ///// <summary>
    ///// Gets the current number of clients connected.
    ///// </summary>
    int ClientCount { get; }

    /// <summary>
    /// Registers a client streamer with the given configuration.
    /// </summary>
    /// <param name="streamerConfiguration">The configuration for the client streamer.</param>
    Task RegisterClientStreamer(Guid ClientId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Stops all video streaming activities.
    /// </summary>
    void Stop();

    /// <summary>
    /// Unregisters a client streamer with the given configuration.
    /// </summary>
    /// <param name="ClientId">The ClientId for the client streamer.</param>
    /// <returns>True if the client streamer is unregistered successfully; otherwise, false.</returns>
    bool UnRegisterClientStreamer(Guid ClientId);

    /// <summary>
    /// Gets all registered client streamer configurations.
    /// </summary>
    /// <returns>A collection of client streamer configurations; null if none found.</returns>
    ICollection<IClientStreamerConfiguration>? GetClientStreamerConfigurations();
}