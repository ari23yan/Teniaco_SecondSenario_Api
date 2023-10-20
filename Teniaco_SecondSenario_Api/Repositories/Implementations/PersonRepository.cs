using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using Teniaco_SecondSenario_Api.Models.Common;
using Teniaco_SecondSenario_Api.Models.Context;
using Teniaco_SecondSenario_Api.Models.Dtos.Person;
using Teniaco_SecondSenario_Api.Models.Entities.Person;
using Teniaco_SecondSenario_Api.Repositories.Interfaces;

namespace Teniaco_SecondSenario_Api.Repositories.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private readonly TeniacoDbContext _context;
        private readonly IMapper _mapper;

        public PersonRepository(TeniacoDbContext teniacoDbContext, IMapper mapper)
        {
            _context = teniacoDbContext;
            _mapper = mapper;

        }

        public async Task<bool> CheckPersonExist(string Mobile)
        {
            return await _context.Persons.AnyAsync(x => x.Mobile == Mobile);
        }

        public async Task<ApiResponse<Int64>> CreatePerson(CreatePersonDto dto)
        {
            if (await CheckPersonExist(dto.Mobile))
            {
                return new ApiResponse<Int64> { IsSuccessFull = false, Message = "User Exist with Same Mobile" };
            }
            Person person = new Person
            {
                BirthDay = Convert.ToDateTime(dto.BirthDay),
                CreatedTime = DateTime.Now,
                LastName = dto.LastName,
                Mobile = dto.Mobile,
                Name = dto.Name,
            };
            _context.Persons.Add(person);
            _context.SaveChanges();
            return new ApiResponse<Int64> { IsSuccessFull = true, Message = "User Succesfully Created" ,Data= person.Id,TotalCount = 1, Status = StatusCodes.Status200OK.ToString() };
        }

        public async Task<ApiResponse<bool>> DeletePerson(long id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            person.IsDeleted = true;
            _context.Update(person);
            _context.SaveChanges();
            return new ApiResponse<bool> { IsSuccessFull = true, Message = "User Succesfully Deleted" };
        }

        public async Task<ApiResponse<PersonDto>> GetPerson(long id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            if (person != null)
            {
                var result = _mapper.Map<Person, PersonDto>(person);
                return new ApiResponse<PersonDto> { IsSuccessFull = true, Message = "SuccessFull", Data = result, Status = StatusCodes.Status200OK.ToString() };
            }
            else
            {
                return new ApiResponse<PersonDto> { IsSuccessFull = false, Message = "Faild", Data = null, Status = StatusCodes.Status404NotFound.ToString() };
            }
        }

        public async Task<ApiResponse<List<PersonDto>>> GetPersons()
        {
            var persons = await _context.Persons.Where(x => x.IsDeleted == false).ToListAsync();
            var result = _mapper.Map<List<Person>, List<PersonDto>>(persons);

            return new ApiResponse<List<PersonDto>> { IsSuccessFull = true, Message = "SuccessFull", Data = result, Status = StatusCodes.Status200OK.ToString(),TotalCount=result.Count() };
        }

        public async Task<ApiResponse<bool>> UpdatePerson(long id,UpdatePersonDto dto)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x=>x.Id == id);
            if (person == null)
            {
                return new ApiResponse<bool> { IsSuccessFull = false, Message = "User Not Found", Status = StatusCodes.Status404NotFound.ToString() };
            }
            person.BirthDay = Convert.ToDateTime(dto.BirthDay);
            person.Name = dto.Name;
            person.LastName = dto.LastName;
            person.LastName=dto.LastName;
            _context.Update(person);
            _context.SaveChanges();
            return new ApiResponse<bool> { IsSuccessFull = true, Message = "SuccessFull", Status = StatusCodes.Status200OK.ToString() };
        }
    }
}
