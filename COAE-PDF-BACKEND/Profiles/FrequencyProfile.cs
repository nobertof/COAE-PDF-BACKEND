using AutoMapper;
using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Models;

namespace COAE_PDF_BACKEND.Profiles
{
    public class FrequencyProfile:Profile
    {
        public FrequencyProfile()
        {
            CreateMap<CreateFrequencyDto, Frequency>();
            CreateMap<UpdateFrequencyDto, Frequency>();
            CreateMap<Frequency, ReadFrequencyDto>();
        }
    }
}
