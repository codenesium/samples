using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IClientRepository
	{
		POCOClient Create(ClientModel model);

		void Update(int id,
		            ClientModel model);

		void Delete(int id);

		POCOClient Get(int id);

		List<POCOClient> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9ef61820a98b39c611de31b2c52cb405</Hash>
</Codenesium>*/