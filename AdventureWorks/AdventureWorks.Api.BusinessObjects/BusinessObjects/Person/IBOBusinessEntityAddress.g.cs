using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOBusinessEntityAddress
	{
		Task<CreateResponse<int>> Create(
			BusinessEntityAddressModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            BusinessEntityAddressModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOBusinessEntityAddress Get(int businessEntityID);

		List<POCOBusinessEntityAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e6c7537ffdbcc0c31998cc92396fcf90</Hash>
</Codenesium>*/