using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Xml;
using System.Xml.Linq;

namespace DAL
{
    public class ApiPhoneDAL
    {
        public static bool useQuizPlay(int quizId)
        {
            try
            {
                string spath = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\answers.xml";

                XDocument doc = XDocument.Load(spath);

                var parent = doc.Descendants("quizes").Single();
                XElement duplicateChild = new XElement("quiz");
                duplicateChild.Add(new XAttribute("idQuiz", quizId));
                parent.Add(duplicateChild);
                doc.Save(spath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool addQuestionToUseQuiz(int quizId, int questionId)
        {
            try
            {
                XElement a = null;
                string spath = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\answers.xml";

                XDocument doc = XDocument.Load(spath);
                var parent = doc.Descendants("quizes").Single().Elements();
                XElement duplicateChild = new XElement("question");
                duplicateChild.Add(new XAttribute("idQustion", questionId));
                parent.Where(q => int.Parse(q.Attribute("idQuiz").Value) == quizId).First().Add(duplicateChild);
                doc.Save(spath);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public static int getNumPlayersQuiz(int quizId)
        {
            try
            {

                string spath = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\pointsPlayers.xml";

                XDocument doc = XDocument.Load(spath);
                int count = doc.Descendants("playersPoints").Single().Elements().Where(q => int.Parse(q.Attribute("idQuiz").Value) == quizId).First().Elements().Count();
                return count;

            }
            catch
            {
                return 0;
            }

        }

        public static List<int> answersPlayers(int quizId, int questionId)
        {
            List<int> answersPlayers = new List<int>() { 0, 0, 0, 0 };


            try
            {
                string spath = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\answers.xml";

                XDocument doc = XDocument.Load(spath);
                var players = doc.Descendants("quizes").Single().Elements().Where(q => int.Parse(q.Attribute("idQuiz").Value) == quizId).First().Elements().Where(q => int.Parse(q.Attribute("idQustion").Value) == questionId).First().Elements();
                answersPlayers[0] = players.Count();
                for (int i = 1; i < 4; i++)
                {
                    answersPlayers[i] = players.Where(p => int.Parse(p.Attribute("answer").Value) == i).Count();

                }

                return answersPlayers;
            }
            catch
            {
                return answersPlayers;
            }

        }

        public static int getNumPlayersPlay(int quizId)
        {
            try
            {
                XElement a = null;
                string spath = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\answers.xml";

                XDocument doc = XDocument.Load(spath);
                var parent = doc.Descendants("quizes").Single().Elements().Elements().Where(q => int.Parse(q.Attribute("idQuiz").Value) == quizId).First();


                return parent.Elements().Last().Elements().Count(); ;

            }
            catch
            {
                return 0;
            }
        }

        public static List<string> theWinners(int quizId)
        {
            List<string> theWinners = new List<string>() { "אין זוכה", "אין זוכה", "אין זוכה" };
            try
            {

                int num = 0, first = 0, second = 0, third = 0;
                string spathPointsPlayers = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\pointsPlayers.xml";
                XDocument doc = XDocument.Load(spathPointsPlayers);
                XElement quiz = doc.Descendants("playersPoints").Elements().Where(q => int.Parse(q.Attribute("idQuiz").Value) == quizId).First();
                foreach (var item in quiz.Elements())
                {
                    if (int.Parse(item.Attribute("pointsPlayer").Value) > first)
                    {
                        third = second;
                        second = first;
                        first = int.Parse(item.Attribute("pointsPlayer").Value);
                    }
                    else if (int.Parse(item.Attribute("pointsPlayer").Value) > second)
                    {
                        third = second;
                        second = int.Parse(item.Attribute("pointsPlayer").Value);

                    }
                    else if (int.Parse(item.Attribute("pointsPlayer").Value) > third)
                    {
                        third = int.Parse(item.Attribute("pointsPlayer").Value);
                    }

                }
                foreach (var item in quiz.Elements())
                {
                    if ((int.Parse(item.Attribute("pointsPlayer").Value) == first) && first != 0)
                        theWinners[0] = item.Attribute("namePlayer").Value;
                    if ((int.Parse(item.Attribute("pointsPlayer").Value) == second) && second != 0)
                        theWinners[1] = item.Attribute("namePlayer").Value;
                    if ((int.Parse(item.Attribute("pointsPlayer").Value) == third) && third != 0)
                        theWinners[2] = item.Attribute("namePlayer").Value;
                }

                return theWinners;
            }
            catch
            {
                return theWinners;
            }
        }
        public static List<string> leadingPlayers(int quizId)
        {
            List<string> leadingPlayers = new List<string>() { "אין זוכה", "אין זוכה", "אין זוכה", "אין זוכה", "אין זוכה" };
            try
            {

                int num = 0, first = 0, second = 0, third = 0, four = 0, five = 0;
                string spathPointsPlayers = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\pointsPlayers.xml";
                XDocument doc = XDocument.Load(spathPointsPlayers);
                XElement quiz = doc.Descendants("playersPoints").Elements().Where(q => int.Parse(q.Attribute("idQuiz").Value) == quizId).First();
                foreach (var item in quiz.Elements())
                {
                    if (int.Parse(item.Attribute("pointsPlayer").Value) > first)
                    {
                        five = four;
                        four = third;
                        third = second;
                        second = first;
                        first = int.Parse(item.Attribute("pointsPlayer").Value);
                    }
                    else if (int.Parse(item.Attribute("pointsPlayer").Value) > second)
                    {
                        five = four;
                        four = third;
                        third = second;
                        second = int.Parse(item.Attribute("pointsPlayer").Value);

                    }
                    else if (int.Parse(item.Attribute("pointsPlayer").Value) > third)
                    {
                        five = four;
                        four = third;
                        third = int.Parse(item.Attribute("pointsPlayer").Value);

                    }
                    else if (int.Parse(item.Attribute("pointsPlayer").Value) > four)
                    {
                        five = four;
                        four = int.Parse(item.Attribute("pointsPlayer").Value);
                    }
                    else if (int.Parse(item.Attribute("pointsPlayer").Value) > five)
                    {
                        five = int.Parse(item.Attribute("pointsPlayer").Value);
                    }
                }
                foreach (var item in quiz.Elements())
                {
                    if ((int.Parse(item.Attribute("pointsPlayer").Value) == first) && first != 0)
                        leadingPlayers[0] = item.Attribute("namePlayer").Value;
                    if ((int.Parse(item.Attribute("pointsPlayer").Value) == second) && second != 0)
                        leadingPlayers[1] = item.Attribute("namePlayer").Value;
                    if ((int.Parse(item.Attribute("pointsPlayer").Value) == third) && third != 0)
                        leadingPlayers[2] = item.Attribute("namePlayer").Value;
                    if ((int.Parse(item.Attribute("pointsPlayer").Value) == four) && four != 0)
                        leadingPlayers[2] = item.Attribute("namePlayer").Value;
                    if ((int.Parse(item.Attribute("pointsPlayer").Value) == five) && five != 0)
                        leadingPlayers[2] = item.Attribute("namePlayer").Value;
                }

                return leadingPlayers;
            }
            catch
            {
                return leadingPlayers;
            }
        }


        public static bool removeQuiz(int quizId)
        {
            try
            {
                string spath = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\answers.xml";
                string spathPointsPlayers = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\pointsPlayers.xml";
                XDocument doc1 = XDocument.Load(spathPointsPlayers);
                XDocument doc2 = XDocument.Load(spath);
                doc1.Descendants("playersPoints").Elements().Where(q => int.Parse(q.Attribute("idQuiz").Value) == quizId).First().Remove();
                doc2.Descendants("quizes").Single().Elements().Where(q => int.Parse(q.Attribute("idQuiz").Value) == quizId).First().Remove();
                doc1.Save(spathPointsPlayers);
                doc2.Save(spath);

                ; return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<string> theFastPlayers(int quizId, int questionId, int correctAnswer)
        {
            List<string> players = new List<string>() { "אין זוכה", "אין זוכה" };
            try
            {
                int points = 5;
                int num = 0;

                string spath = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\answers.xml";
                string spathPointsPlayers = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\pointsPlayers.xml";

                XDocument doc = XDocument.Load(spath);
                XElement question = doc.Descendants("quizes").Single().Elements().Where(q => int.Parse(q.Attribute("idQuiz").Value) == quizId).First()
                    .Elements().Where(que => int.Parse(que.Attribute("idQustion").Value) == questionId).First();
                string namePlayer;
                foreach (var item in question.Elements())
                {
                    if (int.Parse(item.Attribute("answer").Value) == correctAnswer)
                    {

                        XElement quiz = XDocument.Load(spathPointsPlayers).Descendants("playersPoints").Elements().Where(q => int.Parse(q.Attribute("idQuiz").Value) == quizId).First();
                        XElement player = quiz.Elements().Where(p => p.Attribute("phonePlayer").Value == item.Attribute("phonePlayer").Value).FirstOrDefault();
                        player.SetAttributeValue("pointsPlayer", int.Parse(player.Attribute("pointsPlayer").Value) + points);
                        points--;
                        using (QuizTriviaEntities quizTriviaEntities = new QuizTriviaEntities())
                        {
                            if (num < 2)
                            {
                                namePlayer = quizTriviaEntities.Quizs.Where(q => q.quizId == quizId).FirstOrDefault().Users.Where(u => u.phone == item.Attribute("phonePlayer").Value && u.isRegistered == false).FirstOrDefault().fullName;
                                players.Add(namePlayer);
                                num++;
                            }
                        }
                        if (points == 0)
                            return players;
                    }
                }
                return players;


            }
            catch
            {
                return players;
            }
        }

        public static bool addAnswerPlayer(string apiPhone, int? answer, int answerToQuestion)
        {
            try
            {
                string spath = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\answers.xml";

                XDocument doc = XDocument.Load(spath);
                XElement lastAnswer = doc.Descendants("quizes").Single().Elements().Where(q => int.Parse(q.Attribute("idQuiz").Value) == answer).First().Elements().Last();
                //if (lastAnswer.)
                //{
                //    XElement player = lastAnswer.Elements().Where(p => p.Attribute("phonePlayer").Value == apiPhone).First();
                //    if (player.IsEmpty == null)
                //    {
                XElement duplicateChild = new XElement("player");
                duplicateChild.Add(new XAttribute("phonePlayer", apiPhone), new XAttribute("answer", answerToQuestion));
                lastAnswer.Add(duplicateChild);
                //}
                //}

                doc.Save(spath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool addPltayersToUseQuizPlay(int quizId)
        {
            try
            {
                string spath = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\PointsPlayers.xml";

                XDocument doc = XDocument.Load(spath);
                XElement quiz = new XElement("quiz");
                quiz.Add(new XAttribute("idQuiz", quizId));

                List<User> players = UserDAL.listPlayers(quizId);
                foreach (var item in players)
                {
                    XElement duplicateChild = new XElement("player");
                    duplicateChild.Add(new XAttribute("phonePlayer", item.phone),
                        new XAttribute("namePlayer", item.fullName), new XAttribute("pointsPlayer", 0));
                    quiz.Add(duplicateChild);
                }
                doc.Descendants("playersPoints").Single().Add(quiz);

                doc.Save(spath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool updateConnectionPlayer(string ApiPhone)
        {
            try
            {
                XElement a = null;
                string spath = "C:\\Chani\\Chani&Chayale\\angular\\Klick\\Quick_Click-master\\DAL\\answers.xml";

                XDocument doc = XDocument.Load(spath);
                var parent = doc.Descendants("quizes").Single().Elements();
                foreach (var item in parent)
                {
                    a = parent.Elements().Where(e => e.Attribute("phonePlayer").Value == ApiPhone).First();
                    if (a.IsEmpty)
                    {
                        a.Add(new XAttribute("connect", 1));
                        doc.Save(spath);
                        return true;
                    }
                }
                return false;


            }
            catch
            {
                return false;
            }
        }


    }
}
