using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPenRepository
	{
		POCOPen Create(PenModel model);

		void Update(int id,
		            PenModel model);

		void Delete(int id);

		POCOPen Get(int id);

		List<POCOPen> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>26cef5f06d5bc0b59c21df3e5f1dc8b1</Hash>
</Codenesium>*/