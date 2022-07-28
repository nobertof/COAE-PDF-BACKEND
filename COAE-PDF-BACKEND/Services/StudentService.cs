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
    public class StudentService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public StudentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<ReadStudentDto> PegarEstudantes()
        {
            return _mapper.Map<List<ReadStudentDto>>(_context.Students.ToList());
        }

        public ReadStudentDto PegarEstudantePeloId(int id)
        {
            Student student = _context.Students
                .FirstOrDefault(student => student.Id == id);
            if (student != null) 
            {
                return _mapper.Map<ReadStudentDto>(student);
            }
            return null;
        }

        public ReadStudentDto CadastrarEstudante(CreateStudentDto createDto)
        {
            Student student = _mapper.Map<Student>(createDto);
            _context.Students.Add(student);
            _context.SaveChanges();
            ReadStudentDto readDto = _mapper.Map<ReadStudentDto>(student);
            return readDto;
        }

        public Result AtualizarEstudante(int id, CreateStudentDto updateDto)
        {
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);
            if (student == null) return Result.Fail("Estudante não encontrado");
            _mapper.Map(updateDto, student);
            _context.SaveChanges();
            return Result.Ok();

        }

        public Result DeletarProjeto(int id)
        {
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);
            if (student == null) return Result.Fail("Estudante não encontrado");
            _context.Remove(student);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
