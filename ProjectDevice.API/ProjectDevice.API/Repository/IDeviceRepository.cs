using ProjectDevice.API.DTO;
using ProjectDevice.API.Models;

namespace ProjectDevice.API.Repository
{
    public interface IDeviceRepository 
    {
        Task<IEnumerable<Device>> SelectAll();
        Task<DeviceDTO> SelectById(string id);
        Task<DeviceDTO> Insert(DeviceCreateDTO deviceDto);
        void Update(DeviceDTO deviceDto);
        Task<Device> UpdateDeviceFiles(string id, DeviceFilesDTO deviceFilesDTO);
        void Delete(DeviceDTO deviceDto);
        Task Commit();
    }
}
