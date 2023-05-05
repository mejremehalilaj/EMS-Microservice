namespace AuthService.API.Services.Meeting
{
    public class MeetingUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<MeetingService> MeetingCreated { get; set; }
        public List<MeetingService> MeetingInvited { get; set; }
    }
}
