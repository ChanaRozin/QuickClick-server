using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Converts
{
    public class UserConvert
    {
        public static DtoUser FromDalToDto(User userDal)
        {
            DtoUser user = new DtoUser()
            {
                userId = userDal.userId,
                fullName = userDal.fullName,
                phone = userDal.phone,
                email = userDal.email,
                pasword = userDal.pasword,
                dateRegistration = userDal.dateRegistration,
                isRegistered = userDal.isRegistered

            };
            return user;

        }
        public static User FromDtoToDal(DtoUser userDto)
        {
            User user = new User()
            {
                userId = userDto.userId,
                fullName = userDto.fullName,
                phone = userDto.phone,
                email = userDto.email,
                pasword = userDto.pasword,
                dateRegistration = userDto.dateRegistration,
                isRegistered = userDto.isRegistered

            };
            return user;

        }

        public static List<DtoUser> ListFromDalToDto(List<User> players)
        {
            List<DtoUser> playersDto = new List<DtoUser>();
            players.ForEach(p => playersDto.Add(FromDalToDto(p)));
            return playersDto;
        }
    }
}