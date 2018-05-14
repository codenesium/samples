using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmailAddressRepository
	{
		POCOEmailAddress Create(ApiEmailAddressModel model);

		void Update(int businessEntityID,
		            ApiEmailAddressModel model);

		void Delete(int businessEntityID);

		POCOEmailAddress Get(int businessEntityID);

		List<POCOEmailAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmailAddress> GetEmailAddress(string emailAddress1);
	}
}

/*<Codenesium>
    <Hash>72feb22fce749d1f2ed1167b5a14225e</Hash>
</Codenesium>*/