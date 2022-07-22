using DTO.Enums;

namespace DTO.SubjectDto
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public double Summary { get; set; }
        public Status Status { get; set; }
    }
}
