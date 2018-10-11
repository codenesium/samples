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

		Task<Country> CountryByCountryId(int countryId);

		Task<List<Destination>> ByDestinationId(int destinationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>60d38c7a41efa157c3f3a424d877c79e</Hash>
</Codenesium>*/