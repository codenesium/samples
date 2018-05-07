using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerRepository
	{
		int Create(HandlerModel model);

		void Update(int id,
		            HandlerModel model);

		void Delete(int id);

		POCOHandler Get(int id);

		List<POCOHandler> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c2c827a3b34e06f0212a4be004807262</Hash>
</Codenesium>*/