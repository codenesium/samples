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

		Task<List<Destination>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<PipelineStepDestination>> PipelineStepDestinationsByDestinationId(int destinationId, int limit = int.MaxValue, int offset = 0);

		Task<Country> CountryByCountryId(int countryId);
	}
}

/*<Codenesium>
    <Hash>1aa79b5f1250fe0425337f828f24531a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/