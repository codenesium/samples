using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonPhoneRepository
	{
		int Create(PersonPhoneModel model);

		void Update(int businessEntityID,
		            PersonPhoneModel model);

		void Delete(int businessEntityID);

		POCOPersonPhone Get(int businessEntityID);

		List<POCOPersonPhone> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>196bb40dbdc1e162441df5f59dddd3fa</Hash>
</Codenesium>*/