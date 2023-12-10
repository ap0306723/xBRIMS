using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBRIMS.Models
{
    public class NavigationInfoProvider : IProvider<NavigationInfo>
    {
        public brimsEntities db = new brimsEntities();

        public int Delete(NavigationInfo t)
        {
            if (t == null) return 0;
            var model = db.NavigationInfo.ToList().FirstOrDefault(item => t.NavigationID == item.NavigationID);
            if (model == null) return 0;
            db.NavigationInfo.Remove(model);
            int count = db.SaveChanges();
            return count;
        }

        public int Insert(NavigationInfo t)
        {
            if (t == null) return 0;
            if (string.IsNullOrEmpty(t.DamName) && string.IsNullOrEmpty(t.DamNavStrucType)) return 0;
            db.NavigationInfo.Add(t);
            int count = db.SaveChanges();
            return count;
        }

        public List<NavigationInfo> Select()
        {
            return db.NavigationInfo.ToList();
        }

        public int Update(NavigationInfo t)
        {
            throw new NotImplementedException();
        }


    }
}
