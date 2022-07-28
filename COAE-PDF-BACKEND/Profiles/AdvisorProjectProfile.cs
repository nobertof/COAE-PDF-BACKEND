using AutoMapper;
using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Models;

namespace COAE_PDF_BACKEND.Profiles
{
    public class AdvisorProjectProfile:Profile
    {
        public AdvisorProjectProfile()
        {
            CreateMap<CreateAdvisorProjectDto, AdvisorProject>();
            CreateMap<UpdateAdvisorProjectDto, AdvisorProject>();
            CreateMap<AdvisorProject, ReadAdvisorProjectDto>();
        }
    }
}
