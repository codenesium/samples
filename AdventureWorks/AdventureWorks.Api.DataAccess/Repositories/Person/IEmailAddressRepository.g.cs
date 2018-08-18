using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IEmailAddressRepository
	{
		Task<EmailAddress> Create(EmailAddress item);

		Task Update(EmailAddress item);

		Task Delete(int businessEntityID);

		Task<EmailAddress> Get(int businessEntityID);

		Task<List<EmailAddress>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<EmailAddress>> ByEmailAddress(string emailAddress1, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8945aa4363051a86fac489eb82fa021f</Hash>
</Codenesium>*/