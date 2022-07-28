using AutoMapper;
using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Models;

namespace COAE_PDF_BACKEND.Profiles
{
    public class StudentProjectProfile:Profile
    {
        public StudentProjectProfile()
        {
            CreateMap<CreateStudentProjectDto, StudentProject>();
            CreateMap<UpdateStudentProjectDto, StudentProject>();
            CreateMap<StudentProject, ReadStudentProjectDto>();
        }
    }
}
