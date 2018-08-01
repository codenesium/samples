using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonRepository
	{
		Task<Person> Create(Person item);

		Task Update(Person item);

		Task Delete(int businessEntityID);

		Task<Person> Get(int businessEntityID);

		Task<List<Person>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Person>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName);

		Task<List<Person>> ByAdditionalContactInfo(string additionalContactInfo);

		Task<List<Person>> ByDemographic(string demographic);

		Task<List<BusinessEntityContact>> BusinessEntityContacts(int personID, int limit = int.MaxValue, int offset = 0);

		Task<List<EmailAddress>> EmailAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<Password>> Passwords(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<PersonPhone>> PersonPhones(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>188cca65d5727862e43a6bb5a526e9bf</Hash>
</Codenesium>*/