using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IDestinationRepository
	{
		Task<Destination> Create(Destination item);

		Task Update(Destination item);

		Task Delete(int id);

		Task<Destination> Get(int id);

		Task<List<Destination>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepDestination>> PipelineStepDestinations(int destinationId, int limit = int.MaxValue, int offset = 0);

		Task<Country> GetCountry(int countryId);
	}
}

/*<Codenesium>
    <Hash>e2e66dec997398255655cd1fa3dbcd14</Hash>
</Codenesium>*/