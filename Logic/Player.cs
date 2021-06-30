using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Enums;


namespace Logic
{
    public class Player
    {
        public string PlayerName { get; }
        public eBoardSigns Sign { get; }
        public int Score { get; set; }
        public ePlayerType PlayerType { get; set; }

        public Player(eBoardSigns i_DesiredSign, ePlayerType i_PlayerType, string i_PlayerName)
        {
            this.PlayerName = i_PlayerName;
            this.Sign = i_DesiredSign;
            this.PlayerType = i_PlayerType;
            this.Score = 0;
        }

        public void IncreaseScoreByOne()
        {
            Score += 1;
        }
    }
}