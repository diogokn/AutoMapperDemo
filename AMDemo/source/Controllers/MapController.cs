using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AMDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapController : Controller
    {
        private readonly IMapper _mapper;
        public MapController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //Teste de Mapeamento
            var emp = new Employee();
            var empDto = new EmployeeDTO();
            empDto.Name = "Silva";
            empDto.Address = "Rua Sol";
            empDto.Department = "Ti";
            empDto.Salary = 5000;
            empDto.Sub = new SubDTO(); //Teste mapper 
            empDto.Sub.NameSub = "Teste";
            empDto.Sub.FullNameSub = 1; //Teste mapper converte tipos diferentes
            empDto.Sub.Internal = new InternalDTO(); //teste mapper dois niveis de classes
            empDto.Sub.Internal.Code = "A11";
            empDto.Sub.Internal.LineDTO = "C11"; //Teste com nome campos de nomes diferentes

            emp = _mapper.Map<Employee>(empDto);

            return View();
        }
    }

    public class EmployeeDTO
    {
        public string Name { get; set; }

        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }

        public SubDTO Sub { get; set; }
    }
    public class Employee
    {
        public string Name { get; set; }

        public string FullName { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Dept { get; set; }
        public Sub Sub { get; set; }

    }
    public class Sub
    {
        public string NameSub { get; set; }
        public string FullNameSub { get; set; }
        public Internal Internal { get; set; }
    }

    public class SubDTO
    {
        public string NameSub { get; set; }
        public int FullNameSub { get; set; }
        public InternalDTO Internal { get; set; }
    }

    public class Internal
    {
        public string Code { get; set; }
        public string Line { get; set; }
    }

    public class InternalDTO
    {
        public string Code { get; set; }
        public string LineDTO { get; set; }
    }
}
