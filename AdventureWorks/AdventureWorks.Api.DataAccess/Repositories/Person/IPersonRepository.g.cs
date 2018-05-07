using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonRepository
	{
		int Create(PersonModel model);

		void Update(int businessEntityID,
		            PersonModel model);

		void Delete(int businessEntityID);

		POCOPerson Get(int businessEntityID);

		List<POCOPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b9041e1c0d0bf6d9239084f03887dcc0</Hash>
</Codenesium>*/