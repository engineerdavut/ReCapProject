using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentDetailsController : ControllerBase
    {
        IRentDetailService _rentDetailService;

        public RentDetailsController(IRentDetailService rentDetailService)
        {
            _rentDetailService = rentDetailService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _rentDetailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetRentDetailByCustomerId")]
        public IActionResult GetRentDetailByCustomerId(int id)
        {
            var result = _rentDetailService.GetRentDetailByCustomerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetRentDetailsByCarId")]
        public IActionResult GetRentDetailsByCarId(int id)
        {
            var result = _rentDetailService.GetRentDetailByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetRentalsDetail")]
        public IActionResult GetRentalsDetail()
        {
            var result = _rentDetailService.GetRentalsDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetRentDetailById")]
        public IActionResult GetRentDetailById(int id)
        {
            var result = _rentDetailService.GetRentDetailById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAvailableCars")]
        public IActionResult GetAvailableCars()
        {
            var result = _rentDetailService.GetAvailableCars();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(RentDetail rentDetail)
        {
            var result = _rentDetailService.Add(rentDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(RentDetail rentDetail)
        {
            var result = _rentDetailService.Update(rentDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(RentDetail rentDetail)
        {
            var result = _rentDetailService.Delete(rentDetail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
