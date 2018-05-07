using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmailAddressRepository
	{
		int Create(EmailAddressModel model);

		void Update(int businessEntityID,
		            EmailAddressModel model);

		void Delete(int businessEntityID);

		POCOEmailAddress Get(int businessEntityID);

		List<POCOEmailAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>14bf2a38aca3697939e91c898671383f</Hash>
</Codenesium>*/