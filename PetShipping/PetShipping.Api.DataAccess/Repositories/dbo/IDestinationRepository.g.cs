using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IDestinationRepository
	{
		POCODestination Create(ApiDestinationModel model);

		void Update(int id,
		            ApiDestinationModel model);

		void Delete(int id);

		POCODestination Get(int id);

		List<POCODestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c4656d94b11f85616ac6086fac30e291</Hash>
</Codenesium>*/