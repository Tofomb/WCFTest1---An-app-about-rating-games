using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFTest1.Model;

namespace WCFTest1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public void CreateNewGame(string title, int rating)
        {
            using (var ctx = new WCFDBContext())
            {
                ctx.GR.Add(new GameRating { Title = title, Rating = rating });
                ctx.SaveChanges();
                
            }
            ;
        }

        public void DeleteGame(int gamePlacement)
        {
            using (var ctx = new WCFDBContext())
            {
                var gamelist = ctx.GR.OrderByDescending(g => g.Rating).ToList();

                ctx.GR.Remove(gamelist[gamePlacement-1]);
                ctx.SaveChanges();
            }
            ;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<GameRating> GetGameList()
        {
            using (var ctx = new WCFDBContext())
            {
                return ctx.GR.OrderByDescending(g=>g.Rating).ToList();
            }
            ;
        }

        public void UpdateGame(int gamePlacement, string newTitle, int newRating)
        {
            using (var ctx = new WCFDBContext())
            {
                var gamelist = ctx.GR.OrderByDescending(g => g.Rating).ToList();
                var id = gamelist.Where(b => b.Id == gamelist[gamePlacement - 1].Id).FirstOrDefault().Id;
                ctx.GR.Where(g => g.Id == id).FirstOrDefault().Title = newTitle;
                ctx.GR.Where(g => g.Id == id).FirstOrDefault().Rating = newRating;
                
                ctx.SaveChanges();
            }
            ;
        }
    }
}
