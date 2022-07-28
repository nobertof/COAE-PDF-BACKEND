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
    public class AdvisorProjectService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public AdvisorProjectService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadAdvisorProjectDto> PegarAdvisorProjects()
        {
            return _mapper.Map<List<ReadAdvisorProjectDto>>(_context.AdvisorProjects.ToList());
        }

        public ReadAdvisorProjectDto PegarAdvisorProjectPeloId(int id)
        {
            AdvisorProject advisorProject = _context.AdvisorProjects
                .FirstOrDefault(advisorProject => advisorProject.Id == id);
            if (advisorProject == null) return null;
            return _mapper.Map<ReadAdvisorProjectDto>(advisorProject);
        }

        public ReadAdvisorProjectDto CriarAdvisorProject(CreateAdvisorProjectDto createDto)
        {
            AdvisorProject advisorProject = _mapper.Map<AdvisorProject>(createDto);
            _context.AdvisorProjects.Add(advisorProject);
            _context.SaveChanges();
            return _mapper.Map<ReadAdvisorProjectDto>(advisorProject);
        }

        public Result AtualizarAdvisorProject(int id, UpdateAdvisorProjectDto updateDto)
        {
            AdvisorProject advisorProject = _context.AdvisorProjects
                .FirstOrDefault(advisorProject => advisorProject.Id == id);
            if (advisorProject == null) return Result.Fail("Vinculo de orientador a projeto não encontrado");
            _mapper.Map(updateDto, advisorProject);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarAdvisorProject(int id)
        {
            AdvisorProject advisorProject = _context.AdvisorProjects
                 .FirstOrDefault(advisorProject => advisorProject.Id == id);
            if (advisorProject == null) return Result.Fail("Vinculo de orientador a projeto não encontrado");
            _context.Remove(advisorProject);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
