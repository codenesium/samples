using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientRepository
	{
		int Create(ClientModel model);

		void Update(int id,
		            ClientModel model);

		void Delete(int id);

		POCOClient Get(int id);

		List<POCOClient> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>06836e2fd8473d91cadf6c9917e3dc8b</Hash>
</Codenesium>*/