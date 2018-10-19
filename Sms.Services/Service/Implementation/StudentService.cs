using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Sms.Constants;
using Sms.Domain.Dto;
using Sms.Domain.Entities;
using Sms.Domain.Repostories.Interfaces;
using Sms.Services.Service.Interfaces;

namespace Sms.Services.Service.Implementation
{
   public class StudentService:IStudentService
    {
        private readonly IAsyncRepository<Student> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _studentRepository;

        public StudentService(
            IAsyncRepository<Student> asyncRepository,
            IMapper mapper,
            IRepository<Student> studentRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<ResponseMessageDto> AddStudent(StudentDto dto)
        {
            try
            {
                var student =await _asyncRepository.AddAsync(_mapper.Map<Student>(dto));
                return new ResponseMessageDto()
                {
                    Id = student.Id,
                    SuccessMessage = ResponseMessages.InsertionSuccessMessage,
                    Success = true,
                    Error = false
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    FailureMessage = ResponseMessages.InsertionFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        public async Task<IEnumerable<StudentDto>>  GetAll()
        { 
            try
            {
               var result= await _asyncRepository.ListAllAsync<StudentDto>();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseMessageDto> DeleteStudent(StudentDto dto)
        {
            try
            {
                await _asyncRepository.DeleteAsync(_mapper.Map<Student>(dto));
                return new ResponseMessageDto()
                {
                    Id = dto.Id,
                    SuccessMessage = ResponseMessages.DeleteSuccessMessage,
                    Success = true,
                    Error = false
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    FailureMessage = ResponseMessages.DeleteFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        public async Task<StudentDto> GetById(int id)
        {
            try
            {
               return await _asyncRepository.GetByIdAsync<StudentDto>(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseMessageDto> UpdateStudent(StudentDto dto)
        {
            try
            {
                await _asyncRepository.UpdateAsync(_mapper.Map<Student>(dto));
                return new ResponseMessageDto()
                {
                    Id = dto.Id,
                    SuccessMessage = ResponseMessages.UpdateSuccessMessage,
                    Success = true,
                    Error = false
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    FailureMessage = ResponseMessages.UpdateFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }
    }
}
