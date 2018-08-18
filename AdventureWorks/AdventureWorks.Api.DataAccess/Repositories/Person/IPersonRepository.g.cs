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

		Task<List<Person>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Person>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName, int limit = int.MaxValue, int offset = 0);

		Task<List<Person>> ByAdditionalContactInfo(string additionalContactInfo, int limit = int.MaxValue, int offset = 0);

		Task<List<Person>> ByDemographic(string demographic, int limit = int.MaxValue, int offset = 0);

		Task<List<BusinessEntityContact>> BusinessEntityContacts(int personID, int limit = int.MaxValue, int offset = 0);

		Task<List<EmailAddress>> EmailAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<Password>> Passwords(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<PersonPhone>> PersonPhones(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d083d76ff518676c4dbc9ec79dbd4a42</Hash>
</Codenesium>*/