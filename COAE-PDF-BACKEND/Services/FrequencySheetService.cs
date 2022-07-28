using AutoMapper;
using COAE_PDF_BACKEND.Data;
using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace COAE_PDF_BACKEND.Services
{
    public class FrequencySheetService
    {
        AppDbContext _context;
        IMapper _mapper;
        public FrequencySheetService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        internal IEnumerable<ReadFrequencySheetDto> PegarFrequencySheets()
        {
            return _mapper.Map<List<ReadFrequencySheetDto>>(_context.FrequencySheets.ToList());
        }

        internal ReadFrequencySheetDto PegarFrequencySheetPeloId(int id)
        {
            FrequencySheet frequencySheet = _context.FrequencySheets
                .FirstOrDefault(frequencySheet => frequencySheet.Id == id);
            if (frequencySheet == null) return null;
            return _mapper.Map<ReadFrequencySheetDto>(frequencySheet);
        }

        internal ReadFrequencySheetDto CriarFrequencySheet(CreateFrequencySheetDto createDto)
        {
            FrequencySheet frequencySheet = _mapper.Map<FrequencySheet>(createDto);
            _context.FrequencySheets.Add(frequencySheet);
            _context.SaveChanges();
            return _mapper.Map<ReadFrequencySheetDto>(frequencySheet);
        }

        internal Result AtualizarFrequencySheet(int id, UpdateFrequencySheetDto updateDto)
        {
            FrequencySheet frequencySheet = _context.FrequencySheets
                .FirstOrDefault(frequencySheet => frequencySheet.Id == id);
            if (frequencySheet == null) return Result.Fail("Folha de frequencia não encontrada");
            _mapper.Map(updateDto, frequencySheet);
            _context.SaveChanges();
            return Result.Ok();
        }

        internal Result DeletarFrequencySheet(int id)
        {
            FrequencySheet frequencySheet = _context.FrequencySheets
                .FirstOrDefault(frequencySheet => frequencySheet.Id == id);
            if (frequencySheet == null) return Result.Fail("Folha de frequencia não encontrada");
            _context.Remove(frequencySheet);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
