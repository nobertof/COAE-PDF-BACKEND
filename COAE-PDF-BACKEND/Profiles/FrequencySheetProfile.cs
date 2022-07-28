using AutoMapper;
using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Models;

namespace COAE_PDF_BACKEND.Profiles
{
    public class FrequencySheetProfile:Profile
    {
        public FrequencySheetProfile()
        {
            CreateMap<CreateFrequencySheetDto, FrequencySheet>();
            CreateMap<UpdateFrequencySheetDto, FrequencySheet>();
            CreateMap<FrequencySheet, ReadFrequencySheetDto>();
        }
    }
}
