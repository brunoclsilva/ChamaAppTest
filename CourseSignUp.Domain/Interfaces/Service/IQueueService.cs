namespace CourseSignUp.Domain.Interfaces.Service
{
    public interface IQueueService
    {
        public void SendMessage(string message);
    }
}
