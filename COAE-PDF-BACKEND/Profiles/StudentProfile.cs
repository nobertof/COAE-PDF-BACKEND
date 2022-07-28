using AutoMapper;
using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Models;

namespace COAE_PDF_BACKEND.Profiles
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
            CreateMap<Student, ReadStudentDto>();
        }
    }
}
