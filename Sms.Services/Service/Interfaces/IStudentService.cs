using System.Collections.Generic;
using System.Threading.Tasks;
using Sms.Constants;
using Sms.Domain.Dto;

namespace Sms.Services.Service.Interfaces
{
   public interface IStudentService
    {
        Task<ResponseMessageDto> AddStudent(StudentDto dto);
        Task<IEnumerable<StudentDto>> GetAll();
        Task<ResponseMessageDto> DeleteStudent(StudentDto dto);
        Task<StudentDto> GetById(int id);
        Task<ResponseMessageDto> UpdateStudent(StudentDto dto);
    }
}
