using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectDevice.API.Context;
using ProjectDevice.API.DTO;
using ProjectDevice.API.Middlewares.Exceptions;
using ProjectDevice.API.Models;
using ProjectDevice.API.Repository;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;

namespace ProjectDevice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceRepository _repository;
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public DevicesController(IDeviceRepository service, AppDbContext context, IMapper mapper)
        {
            _repository = service;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return Ok( await _repository.SelectAll());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<DeviceDTO>>> GetDeviceById(string id)
        {
            return Ok(await _repository.SelectById(id));
        }

        [HttpPost]
        public async Task<ActionResult<DeviceDTO>> PostDevie([FromForm] DeviceCreateDTO deviceDto)
        {
            DeviceDTO device = await _repository.Insert(deviceDto);
            await _repository.Commit();
            
            return Ok(device);
            
        }


        [HttpPut]
        public async Task<ActionResult<Device>> PatchDevice(DeviceDTO deviceDto)
        {

            _repository.Update(deviceDto);

            await _repository.Commit();

            return NoContent();

        }


        [HttpPost("TestFile")]
        [Consumes("multipart/form-data")]
        public ActionResult TestPostFile([FromForm] TestCreateDTO file)
        {
            
            return Ok(file);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Device>> PatchtDeviceFiles(string id, IFormFile fileFoto, IFormFile fileDocument)
        {

            DeviceFilesDTO deviceDto = new DeviceFilesDTO()
            {
                Foto = fileFoto,
                Document = fileDocument
            };

            await _repository.UpdateDeviceFiles(id, deviceDto);
            await _repository.Commit();

            return NoContent();

        } 

    }
}
