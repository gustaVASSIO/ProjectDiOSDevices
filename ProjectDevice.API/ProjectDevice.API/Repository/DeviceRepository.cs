using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectDevice.API.Context;
using ProjectDevice.API.DTO;
using ProjectDevice.API.Middlewares.Exceptions;
using ProjectDevice.API.Models;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace ProjectDevice.API.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private const string filePath = "Static";
        private AppDbContext _context;
        private IMapper _mapper;

        public DeviceRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Device>> SelectAll()
        {
            return await _context.Devices.ToListAsync();

        }

        public async Task<DeviceDTO> SelectById(string id)
        {
            Device device = await _context.Devices.FirstOrDefaultAsync(x => x.DeviceId == id);

            if (device == null) throw new EntityNotFoundException("Device not found");


            return _mapper.Map<DeviceDTO>(device);
        }

        public async Task<DeviceDTO> Insert(DeviceCreateDTO deviceDto)
        {
            Device device = new Device()
            {
                Name = deviceDto.Name,
                Description = deviceDto.Description,
            };

            if (deviceDto.Foto != null)
            {
                DeleteFileByPath(filePath + "\\" + device.FotoPath);
                device.FotoPath = await HandleFile(deviceDto.Foto);
            }

            if (deviceDto.Document != null)
            {

                DeleteFileByPath(filePath + "\\" + device.DocumentPath);
                device.DocumentPath = await HandleFile(deviceDto.Document);
            }



            _context.Devices.Add(device);

            var dto = _mapper.Map<DeviceDTO>(device);
            
            return dto;


        }
        public void Update(DeviceDTO deviceDto)
        {
            Device device = _mapper.Map<Device>(deviceDto);
            _context.Devices.Update(device);

        }

        public async Task<Device> UpdateDeviceFiles(string id, DeviceFilesDTO deviceFilesDTO)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null) throw new EntityNotFoundException("Device not found");



            if (deviceFilesDTO.Foto != null)
            { 
                DeleteFileByPath(filePath + "\\" + device.FotoPath);
                device.FotoPath = await HandleFile(deviceFilesDTO.Foto);
            }

            if (deviceFilesDTO.Document != null)
            {

                DeleteFileByPath(filePath + "\\" + device.DocumentPath);
                device.DocumentPath = await HandleFile(deviceFilesDTO.Document);
            }

            return device;
        }

        public void Delete(DeviceDTO deviceDto)
        {
            Device device = _mapper.Map<Device>(deviceDto);
            _context.Devices.Remove(device);

        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        private static async Task<string> HandleFile(IFormFile file)
        {
            string fileId = Guid.NewGuid().ToString() + file.FileName;

            using (var stream = System.IO.File.Create(filePath + "\\" + fileId))
            {
                await file.CopyToAsync(stream);

                stream.Flush();
            }

            return fileId;

        }
        private static void DeleteFileByPath(string path)
        {

            try
            {
                System.IO.File.Delete(path);
            }
            catch (Exception e)
            {

            }


        }
    }
}
