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

		Task<List<PipelineStepDestination>> PipelineStepDestinationsByDestinationId(int destinationId, int limit = int.MaxValue, int offset = 0);

		Task<Country> CountryByCountryId(int countryId);
	}
}

/*<Codenesium>
    <Hash>f921d68dca205bb21b649c3c03947cde</Hash>
</Codenesium>*/