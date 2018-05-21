using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IDestinationRepository
	{
		Task<POCODestination> Create(ApiDestinationModel model);

		Task Update(int id,
		            ApiDestinationModel model);

		Task Delete(int id);

		Task<POCODestination> Get(int id);

		Task<List<POCODestination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2a355324ae7f93856376fa36d1556a95</Hash>
</Codenesium>*/