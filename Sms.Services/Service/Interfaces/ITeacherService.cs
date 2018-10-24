using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sms.Constants;
using Sms.Domain.Dto;

namespace Sms.Services.Service.Interfaces
{
   public interface ITeacherService
    {
        Task<ResponseMessageDto> AddTeacher(TeacherDto dto);
        Task<IEnumerable<TeacherDto>> GetAll();
        Task<ResponseMessageDto> DeleteTeacher(TeacherDto dto);
        Task<TeacherDto> GetById(int id);
        Task<ResponseMessageDto> UpdateTeacher(TeacherDto dto);
    }
}
