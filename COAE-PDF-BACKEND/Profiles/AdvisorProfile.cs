using AutoMapper;
using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Models;

namespace COAE_PDF_BACKEND.Profiles
{
    public class AdvisorProfile:Profile
    {
        public AdvisorProfile()
        {
            CreateMap<CreateAdvisorDto, Advisor>();
            CreateMap<UpdateAdvisorDto, Advisor>();
            CreateMap<Advisor, ReadAdvisorDto>();
        }
    }
}
