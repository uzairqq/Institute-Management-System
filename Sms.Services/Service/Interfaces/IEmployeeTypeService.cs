using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sms.Constants;
using Sms.Domain.Dto;

namespace Sms.Services.Service.Interfaces
{
   public interface IEmployeeTypeService
    {
        Task<ResponseMessageDto> AddEmployeType(EmployeTypeDto dto);
        Task<IEnumerable<EmployeTypeDto>> GetAll();
        Task<ResponseMessageDto> DeleteEmployeType(EmployeTypeDto dto);
        Task<EmployeTypeDto> GetById(int id);
        Task<ResponseMessageDto> UpdateEmployeType(EmployeTypeDto dto);
    }
}
