using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
    public partial interface IVehicleCapabilitiesRepository 
    {

        Task<VehicleCapabilities> Create(VehicleCapabilities item);

        Task Update(VehicleCapabilities item);

        Task Delete(int vehicleId);

		Task<VehicleCapabilities> Get(int vehicleId);

		Task<List<VehicleCapabilities>> All(int limit = int.MaxValue, int offset = 0, string query = "");

	     	


		 
		
								Task<Vehicle> VehicleByVehicleId(int vehicleId);
						

		
		




    }
}

/*<Codenesium>
    <Hash>10854e1a45c2a2d47ae38b9f0f6eebea</Hash>
</Codenesium>*/