using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOOtherTransport
	{
		Task<CreateResponse<int>> Create(
			OtherTransportModel model);

		Task<ActionResponse> Update(int id,
		                            OtherTransportModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOOtherTransport GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFOtherTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOOtherTransport> GetWhereDirect(Expression<Func<EFOtherTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>02b1907b32e1312bbdef8b63d7e56ce5</Hash>
</Codenesium>*/