using System;
using DTO;
using DAL;
using System.Linq;
using System.Collections.Generic;

namespace BL
{
    public class UsersBLL
    {
        public static bool Register(DTO.DtoUser user,int quizId)
        {
            return UserDAL.Register(Converts.UserConvert.FromDtoToDal(user),quizId);

        }


        public static DtoUser Login(string usercode, string password)
        {
            User user = UserDAL.Login(usercode, password);
            if (user != null)
                return Converts.UserConvert.FromDalToDto(user);
            return null;
        }

        public static bool DeletePlayer(int userId)
        {
            return UserDAL.DeletePlayer(userId);

        }
      
        public static List<DtoUser> myListPlayers(int idQuiz)
        {
            return Converts.UserConvert.ListFromDalToDto(UserDAL.listPlayers(idQuiz));
        }

        public static bool updatePlayer(DtoUser user)
        {

          return  UserDAL.updatePlayer(Converts.UserConvert.FromDtoToDal(user));
        }
    }
}
