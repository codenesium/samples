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
		Task<CreateResponse<POCOPerson>> Create(
			ApiPersonModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiPersonModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOPerson Get(int businessEntityID);

		List<POCOPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPerson> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName);
		List<POCOPerson> GetAdditionalContactInfo(string additionalContactInfo);
		List<POCOPerson> GetDemographics(string demographics);
	}
}

/*<Codenesium>
    <Hash>5af6a180d0530c9fb8e214ced4e07521</Hash>
</Codenesium>*/