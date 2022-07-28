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
    public class AdvisorService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public AdvisorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadAdvisorDto> PegarAdvisors()
        {
            return _mapper.Map<List<ReadAdvisorDto>>(_context.Advisors.ToList());
        }

        public ReadAdvisorDto PegarAdvisorPeloId(int id)
        {
            Advisor advisor = _context.Advisors
                .FirstOrDefault(advisor => advisor.Id == id);
            if (advisor == null) return null;
            return _mapper.Map<ReadAdvisorDto>(advisor);
        }

        public ReadAdvisorDto CriarAdvisor(CreateAdvisorDto createDto)
        {
            Advisor advisor = _mapper.Map<Advisor>(createDto);
            _context.Advisors.Add(advisor);
            _context.SaveChanges();
            return _mapper.Map<ReadAdvisorDto>(advisor);
        }

        public Result AtualizarAdvisor(int id, UpdateAdvisorDto updateDto)
        {
            Advisor advisor = _context.Advisors
                .FirstOrDefault(advisor => advisor.Id == id);
            if (advisor == null) return Result.Fail("Orientador não encontrado");
            _mapper.Map(updateDto, advisor);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarAdvisor(int id)
        {
            Advisor advisor = _context.Advisors
                .FirstOrDefault(advisor => advisor.Id == id);
            if (advisor == null) return Result.Fail("Orientador não encontrado");
            _context.Remove(advisor);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
