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
    public class ProjectService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ProjectService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadProjectDto> PegarProjetos()
        {
            return _mapper.Map<List<ReadProjectDto>>(_context.Projects);
        }

        public ReadProjectDto CadastrarProjeto(CreateProjectDto createDto)
        {
            Project project = _mapper.Map<Project>(createDto);
            _context.Projects.Add(project);
            _context.SaveChanges();
            return _mapper.Map<ReadProjectDto>(project);
        }

        internal ReadProjectDto PegarProjetosPorId(int Id)
        {
            Project project = _context.Projects.FirstOrDefault(project => project.Id == Id);
            if(project != null)
            {
                ReadProjectDto readDto = _mapper.Map<ReadProjectDto>(project);
                return readDto;
            }
            return null;
        }

        public Result AtualizarProjeto(int id, UpdateProjectDto updateDto)
        {
            Project projeto = _context.Projects.FirstOrDefault(project => project.Id == id);
            if(projeto == null)
            {
                return Result.Fail("Projeto não encontrado");
            }
            _mapper.Map(updateDto, projeto);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarProjeto(int id)
        {
            Project projeto = _context.Projects.FirstOrDefault(projeto => projeto.Id == id);
            if (projeto == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _context.Remove(projeto);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
