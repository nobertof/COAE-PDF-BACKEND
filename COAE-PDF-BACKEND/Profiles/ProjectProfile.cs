using AutoMapper;
using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Models;
using System.Linq;

namespace COAE_PDF_BACKEND.Profiles
{
    public class ProjectProfile :Profile
    {
        public ProjectProfile()
        {
            CreateMap<CreateProjectDto, Project>();
            CreateMap<UpdateProjectDto, Project>();
            CreateMap<Project, ReadProjectDto>()
                .ForMember(project => project.RegisteredAdvisors, opts=>opts
                .MapFrom(project=>project.RegisteredAdvisors.Select
                (p=> new { p.Id,p.Advisor, p.AdvisorId,p.Status})))
                .ForMember(project => project.RegisteredStudents, opts => opts
                .MapFrom(project => project.RegisteredStudents.Select
                (p => new { p.Id, p.Student, p.StudentId, p.Status })))
                .ForMember(project => project.FrequencySheets, opts => opts
                .MapFrom(project => project.FrequencySheets.Select
                (f => new { f.Id, f.Year, f.Month, f.Frequencies })));
        }

    }
}
