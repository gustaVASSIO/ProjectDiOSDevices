using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectDevice.API.Context;
using ProjectDevice.API.DTO;
using ProjectDevice.API.Middlewares.Exceptions;
using ProjectDevice.API.Models;
using ProjectDevice.API.Repository.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ProjectDevice.API.Repository.Classes
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
            return await _context.Devices.AsNoTracking()
                .Include(x => x.Subscriptions)
                .ToListAsync();

        }

        public async Task<DeviceDTO> SelectById(Guid id)
        {
            Device device = await _context.Devices.Include(x => x.Subscriptions)
                .FirstOrDefaultAsync(x => x.DeviceId.Equals(id));

            if (device == null) throw new EntityNotFoundException("Device not found");


            return _mapper.Map<DeviceDTO>(device);
        }

        public async Task<DeviceDTO> Insert(DeviceCreateDTO deviceDto)
        {
            Device device = new Device()
            {
                Name = deviceDto.Name,
                Description = deviceDto.Description
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

            Validator.ValidateObject(device, new ValidationContext(device), validateAllProperties: true);

            _context.Devices.Add(device);

            var dto = _mapper.Map<DeviceDTO>(device);

            return dto;


        }
        public async Task<DeviceDTO> Update(Guid id, DeviceCreateDTO deviceDto)
        {
            Device device = await _context.Devices.FirstOrDefaultAsync(x => x.DeviceId.Equals(id));

            if (device == null) throw new EntityNotFoundException("Device not found");

            device.Name = deviceDto.Name;
            device.Description = deviceDto.Description;

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
            DeviceDTO deviceDtoReturn = _mapper.Map<DeviceDTO>(device);

            return deviceDtoReturn;

        }

        public async Task<Device> UpdateDeviceFiles(Guid id, DeviceFilesDTO deviceFilesDTO)
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

            using (var stream = File.Create(filePath + "\\" + fileId))
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
                File.Delete(path);
            }
            catch (Exception e)
            {

            }


        }
    }
}
