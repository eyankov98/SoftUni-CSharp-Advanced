using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count
            => Players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return $"Invalid player's information.";
            }
            else if (OpenPositions == 0)
            {
                return $"There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return $"Invalid player's rating.";
            }
            else
            {
                Players.Add(player);

                OpenPositions--;

                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            var targetPlayer = Players.FirstOrDefault(p => p.Name == name);

            if (targetPlayer == null)
            {
                return false;
            }

            OpenPositions++;

            Players.Remove(targetPlayer);

            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            int countRemovePlayers = 0;

            while (Players.FirstOrDefault(p => p.Position == position) != null)
            {
                var targetPlayer = Players.FirstOrDefault(p => p.Position == position);

                OpenPositions++;

                Players.Remove(targetPlayer);

                countRemovePlayers++;
            }

            return countRemovePlayers;
        }
        
        public Player RetirePlayer(string name)
        {
            var targetPlayer = Players.FirstOrDefault(p => p.Name == name);

            if (targetPlayer == null)
            {
                return null;
            }

            targetPlayer.Retired = true;

            return targetPlayer;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> awardedPlayers = new List<Player>();

            foreach (var player in Players.Where(p => p.Games >= games))
            {
                awardedPlayers.Add(player);
            }
            

            return awardedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in Players.Where(p => p.Retired != true))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}