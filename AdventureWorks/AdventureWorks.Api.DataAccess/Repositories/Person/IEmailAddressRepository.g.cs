using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmailAddressRepository
	{
		Task<EmailAddress> Create(EmailAddress item);

		Task Update(EmailAddress item);

		Task Delete(int businessEntityID);

		Task<EmailAddress> Get(int businessEntityID);

		Task<List<EmailAddress>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<EmailAddress>> ByEmailAddress(string emailAddress1);
	}
}

/*<Codenesium>
    <Hash>9b4bff2095bdb140795ce3f3b4c5b68b</Hash>
</Codenesium>*/