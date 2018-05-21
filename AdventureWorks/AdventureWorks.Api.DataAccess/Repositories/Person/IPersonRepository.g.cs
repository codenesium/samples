using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonRepository
	{
		Task<POCOPerson> Create(ApiPersonModel model);

		Task Update(int businessEntityID,
		            ApiPersonModel model);

		Task Delete(int businessEntityID);

		Task<POCOPerson> Get(int businessEntityID);

		Task<List<POCOPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOPerson>> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName);
		Task<List<POCOPerson>> GetAdditionalContactInfo(string additionalContactInfo);
		Task<List<POCOPerson>> GetDemographics(string demographics);
	}
}

/*<Codenesium>
    <Hash>d074561126d3f50a2e7a21dc0230d196</Hash>
</Codenesium>*/