﻿using System;
using System.ComponentModel;
using BruTile;
using Mapsui.Geometries;

namespace Mapsui.Fetcher
{
    interface IFetchDispatcher
    {
        FetchOrder TakeFetchOrder();
        void CompleteFetchOrder(TileInfo tileInfo, byte[] tileData, Exception exception);
        void ViewportChanged(BoundingBox newExtent, double newResolution);

        bool Busy { get; }
        int NumberTilesNeeded { get; }

        event DataChangedEventHandler DataChanged;
        event PropertyChangedEventHandler PropertyChanged;

    }
}