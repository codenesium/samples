using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerRepository
	{
		POCOHandler Create(ApiHandlerModel model);

		void Update(int id,
		            ApiHandlerModel model);

		void Delete(int id);

		POCOHandler Get(int id);

		List<POCOHandler> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>53b809b3f08e5937222491cf4e49d518</Hash>
</Codenesium>*/