﻿using SeaBattle.Common.Extensions;
using SeaBattle.Common.Types;

namespace SeaBattle.Domain
{
    public class SearchShipCriteria
    {
        public GameDomainModel Game { get; }
        public Point Coordinate { get; }

        public SearchShipCriteria(GameDomainModel game, Point coordinate)
        {
            Game = game.NotNull(nameof(game));
            Coordinate = coordinate.NotNull(nameof(coordinate));
        }
    }
}
