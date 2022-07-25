using DTO.Enums;

namespace DTO.MajorDto
{
    public class MajorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public int? SchoolId { get; set; }
    }
}
