namespace Dotnet_API_11_.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public required string StudentName {  get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;    
    }
}
