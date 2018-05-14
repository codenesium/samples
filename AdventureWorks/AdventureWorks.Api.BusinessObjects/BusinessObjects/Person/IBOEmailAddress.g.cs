using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOEmailAddress
	{
		Task<CreateResponse<POCOEmailAddress>> Create(
			ApiEmailAddressModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiEmailAddressModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOEmailAddress Get(int businessEntityID);

		List<POCOEmailAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmailAddress> GetEmailAddress(string emailAddress1);
	}
}

/*<Codenesium>
    <Hash>fe9bba39bcd41469c3ea842ba069fa9d</Hash>
</Codenesium>*/