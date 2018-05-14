using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonRepository
	{
		POCOPerson Create(ApiPersonModel model);

		void Update(int businessEntityID,
		            ApiPersonModel model);

		void Delete(int businessEntityID);

		POCOPerson Get(int businessEntityID);

		List<POCOPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPerson> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName);
		List<POCOPerson> GetAdditionalContactInfo(string additionalContactInfo);
		List<POCOPerson> GetDemographics(string demographics);
	}
}

/*<Codenesium>
    <Hash>2a9fb6ea7dac842ba0cb209a84e3dac0</Hash>
</Codenesium>*/