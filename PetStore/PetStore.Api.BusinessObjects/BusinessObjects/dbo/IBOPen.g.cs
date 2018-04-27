using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOPen
	{
		Task<CreateResponse<int>> Create(
			PenModel model);

		Task<ActionResponse> Update(int id,
		                            PenModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOPen GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPen, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPen> GetWhereDirect(Expression<Func<EFPen, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e4f62ca40b5f895a809c0b266753db00</Hash>
</Codenesium>*/