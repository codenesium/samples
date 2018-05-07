using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPerson
	{
		Task<CreateResponse<int>> Create(
			PersonModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            PersonModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOPerson Get(int businessEntityID);

		List<POCOPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>61d8d8903eab9ea1de47255020eecd69</Hash>
</Codenesium>*/