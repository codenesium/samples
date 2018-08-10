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

		Task<List<EmailAddress>> ByEmailAddress(string emailAddress1);
	}
}

/*<Codenesium>
    <Hash>3b554624f614cea06fd45a36d6e394f4</Hash>
</Codenesium>*/