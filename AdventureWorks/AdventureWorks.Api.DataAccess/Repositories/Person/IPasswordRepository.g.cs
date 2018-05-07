using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPasswordRepository
	{
		int Create(PasswordModel model);

		void Update(int businessEntityID,
		            PasswordModel model);

		void Delete(int businessEntityID);

		POCOPassword Get(int businessEntityID);

		List<POCOPassword> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>948bda3e6192d43168d93094049ba22e</Hash>
</Codenesium>*/