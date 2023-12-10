using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBRIMS.Models
{
    public class BridgeInfoProvider : IProvider<BridgeInfo>
    {
        public brimsEntities db = new brimsEntities();
        public int Delete(BridgeInfo t)
        {
            if (t == null) return 0;
            var model = db.BridgeInfo.ToList().FirstOrDefault(item => t.BridgeID == item.BridgeID);
            if (model == null) return 0;
            db.BridgeInfo.Remove(model);
            int count = db.SaveChanges();
            return count;
        }

        public int Insert(BridgeInfo t)
        {
            if (t == null) return 0;
            if (string.IsNullOrEmpty(t.ChnAfairsCenter) || string.IsNullOrEmpty(t.ChnDeptBridgeName)) return 0;
            db.BridgeInfo.Add(t);
            int count = db.SaveChanges();
            return count;
        }

        public List<BridgeInfo> Select()
        {   
            return db.BridgeInfo.ToList();
        }

        public int Update(BridgeInfo t)
        {
            throw new NotImplementedException();
        }
    }
}
