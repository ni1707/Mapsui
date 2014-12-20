﻿// Copyright 2008 - Paul den Dulk (Geodan)
// 
// This file is part of Mapsui.
// Mapsui is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// Mapsui is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with Mapsui; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.Collections.Generic;
using BruTile;
using BruTile.Web;
using BruTile.Predefined;
using BruTile.Wmsc;

namespace Mapsui.Samples.Common
{
    public class GeodanWorldWmsCTileSource : ITileSource
    {
        public GeodanWorldWmsCTileSource()
        {
            Schema = new GlobalSphericalMercator(YAxis.TMS);
            Provider = GetTileProvider(Schema);
        }

        public ITileSchema Schema { get; private set; }
        public string Name { get; private set; }
        public ITileProvider Provider { get; private set; }

        public byte[] GetTile(TileInfo tileInfo)
        {
            return Provider.GetTile(tileInfo);
        }
        
        private static ITileProvider GetTileProvider(ITileSchema schema)
        {
            return new WebTileProvider(GetRequestBuilder(schema));
        }

        private static IRequest GetRequestBuilder(ITileSchema schema)
        {
            const string url = "http://geoserver.nl/tiles/tilecache.aspx?";
            var parameters = new Dictionary<string, string>();
            var request = new WmscRequest(new Uri(url), schema,
              new List<string>(new[] { "world_GM" }), new List<string>(), parameters);
            return request;
        }
    }
}
