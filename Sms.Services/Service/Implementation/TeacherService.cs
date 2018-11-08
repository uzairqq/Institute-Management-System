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
   public class TeacherService:ITeacherService
    {
        private readonly IAsyncRepository<Employee> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Employee> _teacherRepository;

        public TeacherService(
            IAsyncRepository<Employee> asyncRepository,
            IMapper mapper,
            IRepository<Employee> teacherRepository
            )
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        
        public async Task<ResponseMessageDto> AddTeacher(TeacherDto dto)
        {
            try
            {
                var teacher = await _asyncRepository.AddAsync(_mapper.Map<Employee>(dto));
                return new ResponseMessageDto()
                {
                    Id = teacher.Id,
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

        public async Task<IEnumerable<TeacherDto>> GetAll()
        {
            try
            {
                var result = await _asyncRepository.ListAllAsync<TeacherDto>();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseMessageDto> DeleteTeacher(TeacherDto dto)
        {
            try
            {
                await _asyncRepository.DeleteAsync(_mapper.Map<Employee>(dto));
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

        public async Task<TeacherDto> GetById(int id)
        {
            try
            {
                return await _asyncRepository.GetByIdAsync<TeacherDto>(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseMessageDto> UpdateTeacher(TeacherDto dto)
        {
            try
            {
                await _asyncRepository.UpdateAsync(_mapper.Map<Employee>(dto));
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
