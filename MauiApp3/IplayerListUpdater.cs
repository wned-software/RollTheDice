﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3
{
    public interface IplayerListUpdater
    {
        void UpdatePlayerList(List<string> playerList);
    }
}
