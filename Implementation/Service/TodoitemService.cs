using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.DTOs;
using UniqueTodoApplication.Entities;
using UniqueTodoApplication.Enum;
using UniqueTodoApplication.Interface.IRespositries;
using UniqueTodoApplication.Interface.IService;
using UniqueTodoApplication.Models;

namespace UniqueTodoApplication.Implementation.Service
{
    public class TodoitemService : ITodoitemService
    {
        private readonly ITodoitemRepository _todoitemRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IReminderRepository _reminderRepository;

        public TodoitemService(ITodoitemRepository todoitemRepository, IUserRepository userRepository, ICustomerRepository customerRepository, IReminderRepository reminderRepository)
        {
            _todoitemRepository = todoitemRepository;
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _reminderRepository = reminderRepository;
        }

        public async Task<BaseResponse<TodoitemDto>> DeleteTodoitem(int id)
        {
            var todoitem = await _todoitemRepository.Get(id);
            if (todoitem == null)
            {
                return new BaseResponse<TodoitemDto>
                {
                    Message = "Todoitem not found",
                    Success = false
                };
            }
            todoitem.IsDeleted = true;
            await _todoitemRepository.SaveChanges();
            return new BaseResponse<TodoitemDto>
            {
                Message = $"Todoitem with name {todoitem.Name} deleted successfully",
                Success = true,
                Data = new TodoitemDto
                {
                    Id = todoitem.Id,
                    Name = todoitem.Name,
                    Description = todoitem.Description,
                    OriginalTime = todoitem.OriginalTime,
                    StartingTime = todoitem.StartingTime,
                    Status = todoitem.Status,
                    TimeInterval = todoitem.TimeInterval,
                    Priority = todoitem.Priority
                }
            };
        }

        public Task<BaseResponse<IEnumerable<TodoitemDto>>> FetchAllCustomerTaskForToday()
        {
            throw new NotImplementedException();
        }

        private List<DateTime> GenerateInterval(DateTime start, DateTime endTime, string interval)
        {
            var intervalConverted = TimeSpan.Parse(interval);
            List<DateTime> TimeList = new List<DateTime>();
            TimeList.Add(start);
            while (start < endTime)
            {
                var t = start;
                var r = t + intervalConverted;
                TimeList.Add(r);
                start = r;
                var sample = (r.Date.AddHours(r.Hour) + intervalConverted) + intervalConverted;
                if (sample > endTime) { break; }
            }
            if (start < endTime)
            {
                TimeList.Add(endTime);
            }

            return TimeList;

        }

        public async Task<BaseResponse<IEnumerable<TodoitemDto>>> GetAllDoneTask()
        {
            var todoitem = await _todoitemRepository.GetAll(d => d.Status == Status.Done && d.OriginalTime == DateTime.Now.Date && d.IsDeleted == true);
            return new BaseResponse<IEnumerable<TodoitemDto>>
            {
                Message = "Task successfully retrieved",
                Success = true,
                Data = todoitem.Select(todoitem => new TodoitemDto
                {
                    Id = todoitem.Id,
                    Name = todoitem.Name,
                    Description = todoitem.Description,
                    OriginalTime = todoitem.OriginalTime,
                    StartingTime = todoitem.StartingTime,
                    Status = todoitem.Status,
                    TimeInterval = todoitem.TimeInterval,
                    Priority = todoitem.Priority
                }).ToList()
            };
        }

        public async Task<BaseResponse<IEnumerable<TodoitemDto>>> GetAllPastTask()
        {
            var todoitem = await _todoitemRepository.GetAll(d => d.Status == Status.Past && d.IsDeleted == true);
            return new BaseResponse<IEnumerable<TodoitemDto>>
            {
                Message = "Task successfully retrieved",
                Success = true,
                Data = todoitem.Select(todoitem => new TodoitemDto
                {
                    Id = todoitem.Id,
                    Name = todoitem.Name,
                    Description = todoitem.Description,
                    OriginalTime = todoitem.OriginalTime,
                    StartingTime = todoitem.StartingTime,
                    Status = todoitem.Status,
                    TimeInterval = todoitem.TimeInterval,
                    Priority = todoitem.Priority
                }).ToList()
            };
        }

        public async Task<BaseResponse<IEnumerable<TodoitemDto>>> GetAllPendingTask()
        {
            var todoitem = await _todoitemRepository.GetAll(d => d.Status == Status.Pending && d.IsDeleted == true);
            return new BaseResponse<IEnumerable<TodoitemDto>>
            {
                Message = "Task successfully retrieved",
                Success = true,
                Data = todoitem.Select(todoitem => new TodoitemDto
                {
                    Id = todoitem.Id,
                    Name = todoitem.Name,
                    Description = todoitem.Description,
                    OriginalTime = todoitem.OriginalTime,
                    StartingTime = todoitem.StartingTime,
                    Status = todoitem.Status,
                    TimeInterval = todoitem.TimeInterval,
                    Priority = todoitem.Priority
                }).ToList()
            };
        }

        public async Task<BaseResponse<IEnumerable<TodoitemDto>>> GetAllTodoitem()
        {
            var todoitem = await _todoitemRepository.GetAll();
            if (todoitem == null)
            {
                return new BaseResponse<IEnumerable<TodoitemDto>>
                {
                    Message = "Todoitems does not exist",
                    Success = false
                };
            }
            return new BaseResponse<IEnumerable<TodoitemDto>>
            {
                Message = "Todoitems retrieved successfully",
                Success = true,
                Data = todoitem.Select(todoitem => new TodoitemDto
                {
                    Id = todoitem.Id,
                    Name = todoitem.Name,
                    Description = todoitem.Description,
                    OriginalTime = todoitem.OriginalTime,
                    StartingTime = todoitem.StartingTime,
                    Status = todoitem.Status,
                    TimeInterval = todoitem.TimeInterval,
                    Priority = todoitem.Priority,
                    CustomerId = todoitem.CustomerId
                }).ToList()
            };
        }

        public async Task<BaseResponse<TodoitemDto>> GetTodoitem(int id)
        {
            var todoitem = await _todoitemRepository.Get(id);
            if (todoitem == null)
            {
                return new BaseResponse<TodoitemDto>
                {
                    Message = "Todoitem not found",
                    Success = false
                };
            }
            return new BaseResponse<TodoitemDto>
            {
                Message = "Todoitem retrieved successfully",
                Success = true,
                Data = new TodoitemDto
                {
                    Id = todoitem.Id,
                    Name = todoitem.Name,
                    Description = todoitem.Description,
                    OriginalTime = todoitem.OriginalTime,
                    StartingTime = todoitem.StartingTime,
                    Status = todoitem.Status,
                    TimeInterval = todoitem.TimeInterval,
                    Priority = todoitem.Priority,
                    CustomerId = todoitem.CustomerId
                }
            };
        }

        public Task<BaseResponse<TodoitemDto>> GetTodoitemByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<TodoitemDto>> RegisterTodoitem(TodoitemRequestModel model, int id)
        {
             var user = await _userRepository.Get(id);
            var customer = await _customerRepository.GetByEmail(user.Email);
            var todoitem = await _todoitemRepository.ExistsByNameAndTime(model.Name, model.OriginalTime);
            if(todoitem == true)
            {
                return new BaseResponse<TodoitemDto>
                {
                    Message = "Todoitem already exist"
                };
            }
            var todoitems = new Todoitem
            {
                Name = model.Name,
                Description = model.Description,
                Priority = model.Priority,
                TimeInterval = TimeSpan.Parse(model.TimeInterval),
                OriginalTime = model.OriginalTime,
                StartingTime = model.StartingTime,
                CustomerId = customer.Id
            };
             var x = await _todoitemRepository.Create(todoitems);
             List<Reminder> reminders = new List<Reminder>();
            var reminderIntervals = GenerateInterval(model.StartingTime, model.OriginalTime, model.TimeInterval);
            foreach(var time in reminderIntervals)
            {
                var reminder = new Reminder
                {
                   Time = time,
                   TodoitemId = todoitems.Id
                };
               reminders.Add(reminder);
            }
            await _reminderRepository.AddRange(reminders);
            return new BaseResponse<TodoitemDto>
            {
                Message = "Todoitem created successfully",
                Success = true,
                Data = new TodoitemDto
                {
                   Id = todoitems.Id,
                    Name = todoitems.Name,
                    Description = todoitems.Description,
                    OriginalTime = todoitems.OriginalTime,
                    StartingTime = todoitems.StartingTime,
                    Status = todoitems.Status,
                    TimeInterval = todoitems.TimeInterval,
                    Priority = todoitems.Priority
                }
            };
        }

        public async Task<BaseResponse<TodoitemDto>> UpdateTodoitem(int id, UpdateTodoitemRequestModel model)
        {
            var todoitem = await _todoitemRepository.Get(id);
            if (todoitem == null)
            {
                return new BaseResponse<TodoitemDto>
                {
                    Message = "Todoitem to be updated does not exist",
                    Success = false
                };
            }
            todoitem.Description = model.Description ?? todoitem.Description;
            todoitem.Name = model.Name ?? todoitem.Name;
            todoitem.Status = model.Status;
            todoitem.Priority = model.Priority;
            todoitem.TimeInterval = model.TimeInterval;
            todoitem.OriginalTime = model.OriginalTime;
            todoitem.StartingTime = model.StartingTime;
            await _todoitemRepository.Update(todoitem);
            return new BaseResponse<TodoitemDto>
            {
                Message = "Todoitem updated successfully",
                Success = true,
                Data = new TodoitemDto
                {
                    Id = todoitem.Id,
                    Name = todoitem.Name,
                    Description = todoitem.Description,
                    OriginalTime = todoitem.OriginalTime,
                    StartingTime = todoitem.StartingTime,
                    Status = todoitem.Status,
                    TimeInterval = todoitem.TimeInterval,
                    Priority = todoitem.Priority,
                }
            };
        }
    }
}
