﻿namespace StreamMaster.SchedulesDirectAPI;

public static class SDExtensions
{
    public static List<string>? CheckStatus(this SDStatus status)
    {
        List<string> ret = new();

        foreach (Lineup lineup in status.lineups)
        {
            if (lineup.IsDeleted)
            {
                ret.Add($"Lineup {lineup.LineupString} is deleted");
            }
        }

        return ret.Any() ? ret : null;
    }

    public static void OutputFormattedResult(this LineupResult result)
    {
        if (result is null)
        {
            throw new ArgumentNullException(nameof(result));
        }
        Console.WriteLine($"Lineup:\n---------\n");
        foreach (Map map in result.Map)
        {
            Console.WriteLine($"\t\tID: {map.StationId}\n\t\tUhfVhf: {map.UhfVhf}\n\t\tAtscMajor: {map.AtscMajor}\n\t\tAtscMinor: {map.AtscMinor}\n");
        }
        Console.WriteLine($"\nStations:\n---------\n");
        foreach (Station station in result.Stations)
        {
            if (station.Broadcaster == null)
            {
            }
            else
            {
                Console.WriteLine($"\t\tID: {station.StationId}\n\t\tName: {station.Name}\n\t\tCallsign: {station.Callsign}\n\t\tAffiliate: {station.Affiliate}\n\t\tBroadcastLanguage: {string.Join(",", station.BroadcastLanguage)}\n\t\tDescriptionLanguage: {string.Join(",", station.DescriptionLanguage)}\n\t\t\t\tStationLogo:");
            }

            if (station.StationLogo != null)
            {
                foreach (StationLogo stationLogo in station.StationLogo)
                {
                    Console.WriteLine($"\t\t\t\t\t\tURL: {stationLogo.URL}\n\t\t\t\t\t\tHeight: {stationLogo.Height}\n\t\t\t\t\t\tWidth: {stationLogo.Width}\n\t\t\t\t\t\tMd5: {stationLogo.Md5}\n\t\t\t\t\t\tSource: {stationLogo.Source}\n\t\t\t\t\t\tCategory: {stationLogo.Category}\n");
                }
            }
            else
            {
                Console.WriteLine($"\t\t\t\t\tStationLogo: null\n"); //fixed code.
            }
            if (station.Logo != null) //checking if Logo is null too.
            {
                Console.WriteLine($"\t\tLogo:\n\t\t\t\tURL: {station.Logo.URL}\n\t\t\t\tHeight: {station.Logo.Height}\n\t\t\t\tWidth: {station.Logo.Width}\n\t\t\t\tMd5: {station.Logo.Md5}\n\t\t\t\tIsCommercialFree: {station.IsCommercialFree}\n");
            }
            else
            {
                Console.WriteLine($"\t\tLogo: null\n");
            }
        }
        Console.WriteLine($"\nMetadata:\n---------\n");
        Console.WriteLine($"\t\tLineup: {result.Metadata.Lineup}\n\t\tModified: {result.Metadata.Modified}\n\t\tTransport: {result.Metadata.Transport}\n");
    }

    public static void OutputFormattedResult(this LineupsResult result)
    {
        Console.WriteLine($"Code: {result.Code}\nServerID: {result.ServerID}\nDatetime: {result.Datetime}\nLineups:");
        foreach (Lineup lineup in result.Lineups)
        {
            Console.WriteLine($"ID: {lineup.Id}\nLineup: {lineup.LineupString}\nName: {lineup.Name}\nTransport: {lineup.Transport}\nLocation: {lineup.Location}\nUri: {lineup.Uri}\nIsDeleted: {lineup.IsDeleted}\n");
        }
    }
}