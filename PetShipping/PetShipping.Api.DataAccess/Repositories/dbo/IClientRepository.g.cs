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

		ApiResponse GetById(int id);

		POCOClient GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFClient, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOClient> GetWhereDirect(Expression<Func<EFClient, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>38f5076adf686b1f005f9d3a9c17cfeb</Hash>
</Codenesium>*/