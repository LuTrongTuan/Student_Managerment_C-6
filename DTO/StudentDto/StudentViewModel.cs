using DTO.Enums;

namespace DTO.StudentDto
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public Status Status { get; set; }
        public int GradeId { get; set; }
    }
}
