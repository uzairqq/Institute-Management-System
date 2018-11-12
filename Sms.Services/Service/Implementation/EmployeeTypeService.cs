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
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly IAsyncRepository<EmployeeType> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<EmployeeType> _employeeTypeRepository;

        public EmployeeTypeService(
            IAsyncRepository<EmployeeType> asyncRepository,
            IMapper mapper,
            IRepository<EmployeeType> employeeTypeRepository
            )
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _employeeTypeRepository = employeeTypeRepository;
        }
        public async Task<ResponseMessageDto> AddEmployeType(EmployeTypeDto dto)
        {
            try
            {
                var student = await _asyncRepository.AddAsync(_mapper.Map<EmployeeType>(dto));
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

        public async Task<IEnumerable<EmployeTypeDto>> GetAll()
        {
            try
            {
                var result = await _asyncRepository.ListAllAsync<EmployeTypeDto>();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseMessageDto> DeleteEmployeType(EmployeTypeDto dto)
        {
            try
            {
                await _asyncRepository.DeleteAsync(_mapper.Map<EmployeeType>(dto));
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
                throw;
            }
        }

        public async Task<EmployeTypeDto> GetById(int id)
        {
            try
            {
                return await _asyncRepository.GetByIdAsync<EmployeTypeDto>(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseMessageDto> UpdateEmployeType(EmployeTypeDto dto)
        {
            try
            {
                await _asyncRepository.UpdateAsync(_mapper.Map<EmployeeType>(dto));
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
