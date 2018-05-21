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

		Task<POCOPerson> Get(int businessEntityID);

		Task<List<POCOPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOPerson>> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName);
		Task<List<POCOPerson>> GetAdditionalContactInfo(string additionalContactInfo);
		Task<List<POCOPerson>> GetDemographics(string demographics);
	}
}

/*<Codenesium>
    <Hash>b6d2ed1bd34136faa767a70600fd47f3</Hash>
</Codenesium>*/