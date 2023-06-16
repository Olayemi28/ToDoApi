using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.DTOs;
using UniqueTodoApplication.Models;

namespace UniqueTodoApplication.Interface.IService
{
   public interface ITodoitemService
   {
        Task<BaseResponse<TodoitemDto>> RegisterTodoitem(TodoitemRequestModel model, int id);

        Task<BaseResponse<TodoitemDto>> UpdateTodoitem(int id, UpdateTodoitemRequestModel model);

        Task<BaseResponse<TodoitemDto>> GetTodoitem(int id);

        Task<BaseResponse<IEnumerable<TodoitemDto>>> GetAllTodoitem();

        Task<BaseResponse<TodoitemDto>> DeleteTodoitem(int id);

        Task<BaseResponse<IEnumerable<TodoitemDto>>> GetAllDoneTask();

        Task<BaseResponse<IEnumerable<TodoitemDto>>> GetAllPendingTask();

        Task<BaseResponse<IEnumerable<TodoitemDto>>> GetAllPastTask();

        Task<BaseResponse<IEnumerable<TodoitemDto>>> FetchAllCustomerTaskForToday();

        Task<BaseResponse<TodoitemDto>> GetTodoitemByCustomerId(int id);

    }
}
