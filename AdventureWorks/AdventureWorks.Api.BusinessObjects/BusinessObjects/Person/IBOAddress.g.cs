using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOAddress
	{
		Task<CreateResponse<int>> Create(
			AddressModel model);

		Task<ActionResponse> Update(int addressID,
		                            AddressModel model);

		Task<ActionResponse> Delete(int addressID);

		ApiResponse GetById(int addressID);

		POCOAddress GetByIdDirect(int addressID);

		ApiResponse GetWhere(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAddress> GetWhereDirect(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3bff2b2c4401ad0109e17c371dd98fed</Hash>
</Codenesium>*/