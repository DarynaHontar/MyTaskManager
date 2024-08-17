using MyTaskManager.Models;

namespace MyTaskManager.Services
{
    public interface ILifeSphereRepository
    {
        void AddLifeSphere(LifeSphere Sphere);
        LifeSphere? GetLifeSphere(int id);
        List<LifeSphere> GetLifeSpheres();
        bool DeleteLifeSphere(int id);
        bool UpdateLifeSphere(int id, LifeSphere newLifeSphere);
    }
}