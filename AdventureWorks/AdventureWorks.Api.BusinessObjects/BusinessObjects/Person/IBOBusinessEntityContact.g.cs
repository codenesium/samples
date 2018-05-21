using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOBusinessEntityContact
	{
		Task<CreateResponse<POCOBusinessEntityContact>> Create(
			ApiBusinessEntityContactModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiBusinessEntityContactModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<POCOBusinessEntityContact> Get(int businessEntityID);

		Task<List<POCOBusinessEntityContact>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOBusinessEntityContact>> GetContactTypeID(int contactTypeID);
		Task<List<POCOBusinessEntityContact>> GetPersonID(int personID);
	}
}

/*<Codenesium>
    <Hash>2d8a38c5d693694625081315703414f2</Hash>
</Codenesium>*/