using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOAddressType
	{
		Task<CreateResponse<int>> Create(
			AddressTypeModel model);

		Task<ActionResponse> Update(int addressTypeID,
		                            AddressTypeModel model);

		Task<ActionResponse> Delete(int addressTypeID);

		ApiResponse GetById(int addressTypeID);

		POCOAddressType GetByIdDirect(int addressTypeID);

		ApiResponse GetWhere(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAddressType> GetWhereDirect(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f4bee81722cbc0ac3d89c87ca5eb96b5</Hash>
</Codenesium>*/