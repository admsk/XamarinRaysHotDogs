using RaysHotDogs.Core.Models;
using RaysHotDogs.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Service
{
    public class HotDogDataService
    {
        private static HotDogRepository hotDogRepository = new HotDogRepository();

        public List<HotDog> GetAllHotDogs()
        {
            return hotDogRepository.GetAllHotDogs();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogRepository.GetGroupedHotDogs();
        }

        public List<HotDog> GetHotDogForGroup(int hotDogGroupId)
        {
            return hotDogRepository.GetHotDogsForGroups(hotDogGroupId);
        }

        public List<HotDog> GetFavorityHotDog()
        {
            return hotDogRepository.GetFavoriteHotDogs();
        }

        public HotDog GetHotDogbyId(int hotDogId)
        {
            return hotDogRepository.GetHotDogById(hotDogId);
        }
    }
}
