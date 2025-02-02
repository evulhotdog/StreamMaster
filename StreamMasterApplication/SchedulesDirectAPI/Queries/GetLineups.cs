﻿using StreamMaster.SchedulesDirectAPI.Domain.Interfaces;
using StreamMaster.SchedulesDirectAPI.Domain.Models;

namespace StreamMasterApplication.SchedulesDirectAPI.Queries;

public record GetLineups : IRequest<List<Lineup>>;

internal class GetLineupsHandler(ISDService sdService) : IRequestHandler<GetLineups, List<Lineup>>
{
    public async Task<List<Lineup>> Handle(GetLineups request, CancellationToken cancellationToken)
    {
        //Setting setting = await settingsService.GetSettingsAsync(cancellationToken);
        //SchedulesDirect sd = new(setting.ClientUserAgent, setting.SDUserName, setting.SDPassword);
        //bool isReady = await sd.GetSystemReady(cancellationToken).ConfigureAwait(false);
        //if (!isReady)
        //{
        //    Console.WriteLine($"Status is Offline");
        //    return new();
        //}

        List<Lineup> ret = await sdService.GetLineups(cancellationToken).ConfigureAwait(false);

        return ret;
    }
}