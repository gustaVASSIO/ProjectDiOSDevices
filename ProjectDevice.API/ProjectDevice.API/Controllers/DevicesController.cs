using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectDevice.API.DTO;
using ProjectDevice.API.Models;
using ProjectDevice.API.Repository.Interfaces;

namespace ProjectDevice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public DevicesController(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return Ok( await _deviceRepository.SelectAll());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<DeviceDTO>>> GetDeviceById(Guid id)
        {
            return Ok(await _deviceRepository.SelectById(id));
        }

        [HttpPost]
        
        public async Task<ActionResult<DeviceDTO>> PostDevie([FromForm] DeviceCreateDTO deviceDto)
        {
            DeviceDTO device = await _deviceRepository.Insert(deviceDto);
            
            await _deviceRepository.Commit();
            
            return Ok(device);
            
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Device>> PutDevice(Guid id, [FromForm] DeviceCreateDTO deviceDto)
        {

            DeviceDTO device = await _deviceRepository.Update(id, deviceDto);

            await _deviceRepository.Commit();

            return Ok(device);

        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Device>> PatchtDeviceFiles(Guid id, IFormFile fileFoto, IFormFile fileDocument)
        {

            DeviceFilesDTO deviceDto = new DeviceFilesDTO()
            {
                Foto = fileFoto,
                Document = fileDocument
            };

            await _deviceRepository.UpdateDeviceFiles(id, deviceDto);
            await _deviceRepository.Commit();

            return NoContent();

        } 

    }
}
