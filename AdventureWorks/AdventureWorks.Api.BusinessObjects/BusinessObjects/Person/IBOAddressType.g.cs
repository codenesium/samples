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
		Task<CreateResponse<POCOAddressType>> Create(
			ApiAddressTypeModel model);

		Task<ActionResponse> Update(int addressTypeID,
		                            ApiAddressTypeModel model);

		Task<ActionResponse> Delete(int addressTypeID);

		Task<POCOAddressType> Get(int addressTypeID);

		Task<List<POCOAddressType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOAddressType> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>d39919c345b32c7325d92176a1eea580</Hash>
</Codenesium>*/