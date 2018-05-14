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

		POCOBusinessEntityContact Get(int businessEntityID);

		List<POCOBusinessEntityContact> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBusinessEntityContact> GetContactTypeID(int contactTypeID);
		List<POCOBusinessEntityContact> GetPersonID(int personID);
	}
}

/*<Codenesium>
    <Hash>6b4d55014439a02a1bc033c7fb228154</Hash>
</Codenesium>*/