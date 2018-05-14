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

		POCOAddressType Get(int addressTypeID);

		List<POCOAddressType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOAddressType GetName(string name);
	}
}

/*<Codenesium>
    <Hash>be165083249ecfa2da96c75cba34eeb0</Hash>
</Codenesium>*/