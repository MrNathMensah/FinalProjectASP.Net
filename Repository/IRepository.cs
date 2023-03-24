using ASP.NETFinalExamsProject.Entities;
using ASP.NETFinalExamsProject.Models;

namespace ASP.NETFinalExamsProject.Repository
{
    public interface IRepository
    {
        public String AddCalls(CallTrackerClass callTrackerClass);

        public IEnumerable<CallTrackerClass> GetAllCalls();

        public CallTrackerClass GetCalls(int Id);
        public CallTrackerClass UpdateCalls(int Id, CallTrackerClass callTrackerClass);

        public void DeleteCalls(int Id);

        public double CalculateCallCost(int duration, string callType);
    } 

    public class CallRepo : IRepository
    {
        private readonly CallContext _callContext;

        public CallRepo(CallContext callContext)
        {
            _callContext = callContext;
        }

        public String AddCalls(CallTrackerClass callTrackerClass)
        {
            try
            {
                var model = _callContext.CallTrackerClasses.Add(callTrackerClass);
                _callContext.SaveChanges();
                return "Call added successfully";
            }
            catch
            {
                return "Error adding Call";
            }
        }


        public void DeleteCalls(int Id)
        {
            var model = _callContext.CallTrackerClasses.FirstOrDefault(c => c.Id == Id);
            _callContext.CallTrackerClasses.Remove(model);
            _callContext.SaveChanges();
        }

        public IEnumerable<CallTrackerClass> GetAllCalls()
        {
            var model = _callContext.CallTrackerClasses.ToList();
            return model;
        }

        public CallTrackerClass GetCalls(int Id)
        {
            var model = _callContext.CallTrackerClasses.FirstOrDefault(c => c.Id == Id);
            return model;
        }

        public CallTrackerClass UpdateCalls(int Id, CallTrackerClass callTrackerClass)
        {
            var model = _callContext.CallTrackerClasses.FirstOrDefault(c => c.Id == Id);
            _callContext.CallTrackerClasses.Update(callTrackerClass);
            _callContext.SaveChanges();
            return callTrackerClass;

        }

        public double CalculateCallCost(int duration, string callType)
        {
            double costPerMinute;

            switch (callType.ToLower())
            {
                case "cell phone":
                    costPerMinute = 0.10;
                    break;
                case "fixed line":
                    costPerMinute = 0.08;
                    break;
                case "international":
                    costPerMinute = 2.0;
                    break;
                default:
                    throw new ArgumentException("Invalid call type");
            }

            int callDurationInMinutes = duration / 60;
            if (duration % 60 >= 30)
            {
                callDurationInMinutes++;
            }

            return costPerMinute * callDurationInMinutes;
        }
    }
}
