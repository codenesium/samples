using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmailAddressRepository
	{
		Task<EmailAddress> Create(EmailAddress item);

		Task Update(EmailAddress item);

		Task Delete(int businessEntityID);

		Task<EmailAddress> Get(int businessEntityID);

		Task<List<EmailAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<EmailAddress>> GetEmailAddress(string emailAddress1);
	}
}

/*<Codenesium>
    <Hash>ec5b508b8d59488ec2fa7486bd55f4ff</Hash>
</Codenesium>*/