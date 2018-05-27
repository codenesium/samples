using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonRepository
	{
		Task<DTOPerson> Create(DTOPerson dto);

		Task Update(int businessEntityID,
		            DTOPerson dto);

		Task Delete(int businessEntityID);

		Task<DTOPerson> Get(int businessEntityID);

		Task<List<DTOPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOPerson>> GetLastNameFirstNameMiddleName(string lastName,string firstName,string middleName);
		Task<List<DTOPerson>> GetAdditionalContactInfo(string additionalContactInfo);
		Task<List<DTOPerson>> GetDemographics(string demographics);
	}
}

/*<Codenesium>
    <Hash>7c5621b81d27982702bd8970cdc7be6f</Hash>
</Codenesium>*/