using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOAirTransport
	{
		Task<CreateResponse<int>> Create(
			AirTransportModel model);

		Task<ActionResponse> Update(int airlineId,
		                            AirTransportModel model);

		Task<ActionResponse> Delete(int airlineId);

		ApiResponse GetById(int airlineId);

		POCOAirTransport GetByIdDirect(int airlineId);

		ApiResponse GetWhere(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAirTransport> GetWhereDirect(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3338aed27b0f7387ccb371ff9b561fe0</Hash>
</Codenesium>*/