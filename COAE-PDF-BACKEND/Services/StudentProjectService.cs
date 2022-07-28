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
    public class StudentProjectService
    {
        AppDbContext _context;
        IMapper _mapper;

        public StudentProjectService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ReadStudentProjectDto> PegarStudentProjects()
        {
            return _mapper.Map<List<ReadStudentProjectDto>>(_context.StudentProjects.ToList());
        }

        public ReadStudentProjectDto PegarStudentProjectPeloId(int id)
        {
            StudentProject studentProject = _context.StudentProjects
                .FirstOrDefault(studentProject => studentProject.Id == id);
            if (studentProject == null) return null;
            return _mapper.Map<ReadStudentProjectDto>(studentProject);
        }

        public ReadStudentProjectDto CriarStudentProject(CreateStudentProjectDto createDto)
        {
            StudentProject studentProject = _mapper.Map<StudentProject>(createDto);
            _context.StudentProjects.Add(studentProject);
            _context.SaveChanges();
            return _mapper.Map<ReadStudentProjectDto>(studentProject);

        }

        public Result AtualizarStudentProject(int id, UpdateStudentProjectDto updateDto)
        {
            StudentProject studentProject = _context.StudentProjects
                .FirstOrDefault(studentProject => studentProject.Id == id);
            if (studentProject == null) return Result.Fail("Vinculo de estudante a projeto não encontrado");
            _mapper.Map(updateDto, studentProject);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarStudentProject(int id)
        {
            StudentProject studentProject = _context.StudentProjects
                .FirstOrDefault(studentProject => studentProject.Id == id);
            if (studentProject == null) return Result.Fail("Vinculo de estudante a projeto não encontrado");
            _context.Remove(studentProject);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
