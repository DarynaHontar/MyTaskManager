using MyTaskManager.Models;

namespace MyTaskManager.Services
{
    public class LifeSphereService: ILifeSphereService
    {
        private readonly ILifeSphereRepository register;
        public LifeSphereService(ILifeSphereRepository register)
        {
            this.register = register;
        }
        public void AddLifeSphere(CreateLifeSphereRequest request)
        {
            LifeSphere lifeSphere = new();
            InitializeLifeSphere(lifeSphere, request);
            register.AddLifeSphere(lifeSphere);
        }

        public bool DeleteLifeSphere(int id)
        {
            int count = register.GetLifeSpheres().Count;
            var lifeSphere = register.GetLifeSphere(id);
            if (lifeSphere == null) return false;
            register.DeleteLifeSphere(id);
            int countAfterDeleting = register.GetLifeSpheres().Count;
            if (countAfterDeleting >= count) return false;
            return true;
        }

        public LifeSphere? GetLifeSphereById(int id)
        {
            return register.GetLifeSphere(id);
        }

        public List<LifeSphere> GetLifeSpheres()
        {
            return register.GetLifeSpheres();
        }

        public LifeSphere? UpdateLifeSphere(int id, CreateLifeSphereRequest request)
        {
            var lifeSphere = register.GetLifeSphere(id);
            if (lifeSphere != null)
            {
                InitializeLifeSphere(lifeSphere, request);
                register.UpdateLifeSphere(id, lifeSphere);
            }
            return lifeSphere;
        }

        private static LifeSphere InitializeLifeSphere(LifeSphere lifeSphere, CreateLifeSphereRequest request)
        {
            lifeSphere.Title = request.Title;
            lifeSphere.Grade = request.Grade;
            return lifeSphere;
        }
    }
}