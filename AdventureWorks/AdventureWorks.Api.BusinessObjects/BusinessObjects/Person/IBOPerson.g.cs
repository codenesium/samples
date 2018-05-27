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
		Task<CreateResponse<ApiPersonResponseModel>> Create(
			ApiPersonRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiPersonRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiPersonResponseModel> Get(int businessEntityID);

		Task<List<ApiPersonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiPersonResponseModel>> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName);
		Task<List<ApiPersonResponseModel>> GetAdditionalContactInfo(string additionalContactInfo);
		Task<List<ApiPersonResponseModel>> GetDemographics(string demographics);
	}
}

/*<Codenesium>
    <Hash>1466fe35fe77d4d5aa12da94997558a9</Hash>
</Codenesium>*/