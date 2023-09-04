using AutoMapper;
using ProjectDevice.API.DTO;
using ProjectDevice.API.Models;

namespace server.Config
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<DeviceDTO, Device>().ReverseMap();
                conf.CreateMap<DeviceCreateDTO, Device>().ReverseMap();

            });
            return mappConfig;
        }
    }
}