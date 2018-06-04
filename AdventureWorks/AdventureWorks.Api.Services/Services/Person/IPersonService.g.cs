using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IPersonService
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
    <Hash>eaf9e01a9d6e9d71997104c029f4b63c</Hash>
</Codenesium>*/