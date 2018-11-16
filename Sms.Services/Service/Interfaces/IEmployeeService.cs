using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sms.Constants;
using Sms.Domain.Dto;

namespace Sms.Services.Service.Interfaces
{
   public interface IEmployeeService
    {
        Task<ResponseMessageDto> AddEmployee(EmployeeDto dto);
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<ResponseMessageDto> DeleteEmployee(EmployeeDto dto);
        Task<EmployeeDto> GetById(int id);
        Task<ResponseMessageDto> UpdateEmployee(EmployeeDto dto);
    }
}
