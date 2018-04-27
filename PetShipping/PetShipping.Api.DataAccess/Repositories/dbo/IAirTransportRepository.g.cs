using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirTransportRepository
	{
		int Create(AirTransportModel model);

		void Update(int airlineId,
		            AirTransportModel model);

		void Delete(int airlineId);

		ApiResponse GetById(int airlineId);

		POCOAirTransport GetByIdDirect(int airlineId);

		ApiResponse GetWhere(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAirTransport> GetWhereDirect(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d50f910ded07f41499e260447822845f</Hash>
</Codenesium>*/