using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Api.DTO;
using Employee.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeDbContext _dbcontext;

        public EmployeeController(EmployeeDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        [Route("zero/project")]
        [HttpGet]
        public async Task<IActionResult> NoProject()
        {
            List<EmployeeDTO> employeeDTO = new List<EmployeeDTO>();
            try
            {
                var employees = await _dbcontext.Employees.Where(x => !_dbcontext.ProjectEngagements.Select(y => y.EmployeeId)
                                                                                                    .Contains(x.EmployeeId))
                                                          .ToListAsync();

                employees.ForEach(x =>
                {
                    employeeDTO.Add(new EmployeeDTO
                    {
                        EmployeeId = x.EmployeeId,
                        Name = x.Name,
                        BaseLocation = x.BaseLocation

                    });
                });

                return Ok(employeeDTO);
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception);
            }
        }

        [Route("single/project")]
        [HttpGet]
        public async Task<IActionResult> SingleProject()
        {
            List<EmployeeDTO> employeeDTO = new List<EmployeeDTO>();
            try
            {
                var employees = await _dbcontext.Employees.Where(x => _dbcontext.ProjectEngagements.Where(y => y.EmployeeId == x.EmployeeId)
                                                                                                   .Count()
                                                                                                   .Equals(1))
                                                          .ToListAsync();

                employees.ForEach(x =>
                {
                    employeeDTO.Add(
                        new EmployeeDTO
                        {
                            EmployeeId = x.EmployeeId,
                            Name = x.Name,
                            BaseLocation = x.BaseLocation
                        });
                });
                return Ok(employeeDTO);
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception);
            }          
        }

        [Route("multiple/projects")]
        [HttpGet]
        public async Task<IActionResult> MultipleProjects()
        {
            List<EmployeeDTO> employeeDTO = new List<EmployeeDTO>();
            try
            {
                var employees = await _dbcontext.Employees.Where(x => _dbcontext.ProjectEngagements.Where(y => y.EmployeeId == x.EmployeeId)
                                                                                                   .Count() > 1)
                                                          .ToListAsync();
                employees.ForEach(x =>
                {

                    employeeDTO.Add(
                        new EmployeeDTO
                        {
                            EmployeeId = x.EmployeeId,
                            Name = x.Name,
                            BaseLocation = x.BaseLocation
                        });
                });
                return Ok(employeeDTO);
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception);
            }
        }
    }
}