using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IPersonRepository
	{
		Task<Person> Create(Person item);

		Task Update(Person item);

		Task Delete(int businessEntityID);

		Task<Person> Get(int businessEntityID);

		Task<List<Person>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Person> ByRowguid(Guid rowguid);

		Task<List<Person>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName, int limit = int.MaxValue, int offset = 0);

		Task<List<Person>> ByAdditionalContactInfo(string additionalContactInfo, int limit = int.MaxValue, int offset = 0);

		Task<List<Person>> ByDemographic(string demographic, int limit = int.MaxValue, int offset = 0);

		Task<List<Password>> PasswordsByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<BusinessEntity> BusinessEntityByBusinessEntityID(int businessEntityID);
	}
}

/*<Codenesium>
    <Hash>7d8a1567bb191e5b4b18bfbed4cc5590</Hash>
</Codenesium>*/