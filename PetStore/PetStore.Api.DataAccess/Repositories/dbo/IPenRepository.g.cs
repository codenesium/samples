using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPenRepository
	{
		POCOPen Create(ApiPenModel model);

		void Update(int id,
		            ApiPenModel model);

		void Delete(int id);

		POCOPen Get(int id);

		List<POCOPen> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fec8b737d131d264d1ed4f85fe486837</Hash>
</Codenesium>*/