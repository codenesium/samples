using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientRepository
	{
		POCOClient Create(ApiClientModel model);

		void Update(int id,
		            ApiClientModel model);

		void Delete(int id);

		POCOClient Get(int id);

		List<POCOClient> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5889e81db202def5db27d62847f98f2c</Hash>
</Codenesium>*/