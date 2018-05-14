using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerRepository
	{
		POCOHandler Create(HandlerModel model);

		void Update(int id,
		            HandlerModel model);

		void Delete(int id);

		POCOHandler Get(int id);

		List<POCOHandler> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b478632aa96d59221fc67026b6392b2e</Hash>
</Codenesium>*/