using AutoMapper;
using COAE_PDF_BACKEND.Data;
using COAE_PDF_BACKEND.Data.Dto;
using COAE_PDF_BACKEND.Models;
using FluentResults;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace COAE_PDF_BACKEND.Services
{
    public class FrequencyService
    {
        private AppDbContext _context;
        private IMapper _mapper; 
        public FrequencyService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadFrequencyDto> PegarFrequencys()
        {
            return _mapper.Map<List<ReadFrequencyDto>>(_context.Frequencies.ToList());
        }

        public ReadFrequencyDto PegarFrequencyPeloId(int id)
        {
            Frequency frequency = _context.Frequencies
                .FirstOrDefault(frequency => frequency.Id == id);
            if (frequency == null) return null;
            return _mapper.Map<ReadFrequencyDto>(frequency);
        }

        public ReadFrequencyDto CriarFrequency(CreateFrequencyDto createDto)
        {
            Frequency frequency = _mapper.Map<Frequency>(createDto);
            _context.Frequencies.Add(frequency);
            _context.SaveChanges();
            return _mapper.Map<ReadFrequencyDto>(frequency);
        }

        public Result AtualizarFrequency(int id, UpdateFrequencyDto updateDto)
        {
            Frequency frequency = _context.Frequencies
                .FirstOrDefault(frequency => frequency.Id == id);
            if (frequency == null) return Result.Fail("Frequencia não encontrada");
            _mapper.Map(updateDto, frequency);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarFrequency(int id)
        {
            Frequency frequency = _context.Frequencies
                .FirstOrDefault(frequency => frequency.Id == id);
            if (frequency == null) return Result.Fail("Frequencia não encontrada");
            _context.Remove(frequency);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
