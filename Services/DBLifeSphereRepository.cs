using Microsoft.EntityFrameworkCore;
using MyTaskManager.Models;

namespace MyTaskManager.Services
{
    public class DBLifeSphereRepository : ILifeSphereRepository
    {
        public ApplicationDBContext DbContext { get; }
        public DBLifeSphereRepository(ApplicationDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public void AddLifeSphere(LifeSphere lifeSphere)
        {
            DbContext.LifeSpheres.Add(lifeSphere);
            DbContext.SaveChanges();
        }

        public bool DeleteLifeSphere(int id)
        {
            LifeSphere? lifeSphere = DbContext.LifeSpheres.FirstOrDefault(x => x.Id == id);
            if (lifeSphere == null) return false;
            DbContext.LifeSpheres.Remove(lifeSphere);
            DbContext.SaveChanges();
            return true;
        }

        public LifeSphere? GetLifeSphere(int id)
        {
            return DbContext.LifeSpheres.
                Include(x => x.TaskItems).
                FirstOrDefault(x => x.Id == id);
        }

        public List<LifeSphere> GetLifeSpheres()
        {
            return DbContext.LifeSpheres.ToList();
        }

        public bool UpdateLifeSphere(int id, LifeSphere newLifeSphere)
        {
            var lifeSphere = DbContext.LifeSpheres.FirstOrDefault(x => x.Id == id);
            {
                if (lifeSphere == null) return false;
                lifeSphere = newLifeSphere;
                DbContext.SaveChanges();
                return true;
            }
        }
    }
}