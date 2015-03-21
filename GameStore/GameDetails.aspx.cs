﻿using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;

namespace GameStore
{
    public partial class GameDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static List<GamesWithImages> JoinGamesImage([QueryString("id")] int? ItemID)
        {
            GameStoreContext cxt = new GameStoreContext();
            List<GamesWithImages> listOfGI = (from game in cxt.Games
                                              join image in cxt.Images on game.GameID equals image.GameID
                                              select new GamesWithImages { currentGame = game, currentImage = image }).ToList();
            if (ItemID.HasValue && ItemID > 0)
            {
                listOfGI = listOfGI.Where(p => p.currentGame.GameID == ItemID).ToList();
            }
            return listOfGI;
        }
    }
}