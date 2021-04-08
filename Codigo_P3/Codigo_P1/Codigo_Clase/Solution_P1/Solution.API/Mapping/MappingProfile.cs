using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = Solution.DO.Objects;

namespace Solution.API.Mapping
{
    // Implementamos el casteo de objetos del automapper para no tener referencias circulares
    public class MappingProfile:Profile
    {

        public MappingProfile() {

            // Representa el casting del objeto a el similar 
            // Desde DO hacia DataModels 
            // Domain to Resource

            CreateMap<data.Foci, DataModels.Foci>().ReverseMap();

            CreateMap<data.GroupInvitations, DataModels.GroupInvitations>().ReverseMap();

            CreateMap<data.GroupRequests, DataModels.GroupRequests>().ReverseMap();

            CreateMap<data.Groups, DataModels.Groups>().ReverseMap();

        }

    }
}
