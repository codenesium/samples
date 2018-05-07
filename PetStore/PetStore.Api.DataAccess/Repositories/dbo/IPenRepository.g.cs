using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPenRepository
	{
		int Create(PenModel model);

		void Update(int id,
		            PenModel model);

		void Delete(int id);

		POCOPen Get(int id);

		List<POCOPen> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c1ef96d92e5fb2317c062838179b1b50</Hash>
</Codenesium>*/