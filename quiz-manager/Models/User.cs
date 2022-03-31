namespace quiz_manager.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Permissions { get; set; } = null!;
    }
}
