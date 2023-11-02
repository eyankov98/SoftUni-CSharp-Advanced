using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }

        public int Count 
            => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (StorageCapacity > Shoes.Count)
            {
                Shoes.Add(shoe);

                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }

            return "No more space in the storage room.";
        }

        public int RemoveShoes(string material)
        {
            int removeShoes = 0;

            for (int i = 0; i < Shoes.Count; i++)
            {
                if (Shoes[i].Material == material.ToLower())
                {
                    Shoes.RemoveAt(i--);

                    removeShoes++;
                }
            }

            return removeShoes;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> listToReturn = new List<Shoe>();

            foreach (var shoe in Shoes)
            {
                if (shoe.Type == type.ToLower())
                {
                    listToReturn.Add(shoe);
                }
            }

            return listToReturn;
        }

        public Shoe GetShoeBySize(double size)
            => Shoes.FirstOrDefault(sh => sh.Size == size);

        public string StockList(double size, string type)
        {
            List<Shoe> stockList =Shoes.Where(sh => sh.Size == size && sh.Type == type).ToList();

            StringBuilder sb = new StringBuilder();

            if (stockList.Count == 0)
            {
                sb.AppendLine("No matches found!");
            }
            else
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (var shoe1 in stockList)
                {
                    sb.AppendLine(shoe1.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}