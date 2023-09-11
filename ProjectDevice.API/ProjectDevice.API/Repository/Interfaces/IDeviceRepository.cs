using ProjectDevice.API.DTO;
using ProjectDevice.API.Models;

namespace ProjectDevice.API.Repository.Interfaces
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> SelectAll();
        Task<DeviceDTO> SelectById(Guid id);
        Task<DeviceDTO> Insert(DeviceCreateDTO deviceDto);
        Task<DeviceDTO> Update(Guid id, DeviceCreateDTO deviceDto);
        Task<Device> UpdateDeviceFiles(Guid id, DeviceFilesDTO deviceFilesDTO);
        void Delete(DeviceDTO deviceDto);
        Task Commit();
    }
}
