using RaysHotDogs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>()
        {
            new HotDogGroup()
            {
                HotDogGrouId=1,Title="Meat Lovers",ImagePath="",HotDogs=new List<HotDog>()
                {
                    new HotDog()
                    {
                        HotDogId=1,
                        Name="Regular Hot Dog",
                        ShortDescription="Manchelo smelly chesse danish",
                        Imagepath="hotdog1",
                        Available=true,
                        PrepTime=10,
                        Ingredientes=new List<string> {"Regular bun","Sausage","Ketchup" },
                        Price=8,
                        IsFavorite=true
                    },
                    new HotDog()
                    {
                        HotDogId=2,
                        Name="Regular Hot Dog",
                        ShortDescription="Manchelo smelly chesse danish",
                        Imagepath="hotdog1",
                        Available=true,
                        PrepTime=10,
                        Ingredientes=new List<string> {"Regular bun","Sausage","Ketchup" },
                        Price=8,
                        IsFavorite=true
                    },
                    new HotDog()
                    {
                        HotDogId=3,
                        Name="Regular Hot Dog",
                        ShortDescription="Manchelo smelly chesse danish",
                        Imagepath="hotdog1",
                        Available=true,
                        PrepTime=10,
                        Ingredientes=new List<string> {"Regular bun","Sausage","Ketchup" },
                        Price=8,
                        IsFavorite=true
                    }
                }
            }
        };
        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                select hotDog;
            return hotDogs.ToList<HotDog>();
        }
        public HotDog GetHotDogById(int hotDogid)
        {
            IEnumerable<HotDog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                where hotDog.HotDogId == hotDogid
                select hotDog;
            return hotDogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogGroups;
        }
        public List<HotDog> GetHotDogsForGroups(int hotDogGroupedId)
        {
            var group = hotDogGroups.Where(h => h.HotDogGrouId == hotDogGroupedId).FirstOrDefault();
            if (group != null)
                return group.HotDogs;
            return null;
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            IEnumerable<HotDog> hotDogs =
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                where hotDog.IsFavorite == true
                select hotDog;
            return hotDogs.ToList<HotDog>();
        }
    }
}
