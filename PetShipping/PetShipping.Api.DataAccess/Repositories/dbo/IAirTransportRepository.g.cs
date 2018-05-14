using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirTransportRepository
	{
		POCOAirTransport Create(ApiAirTransportModel model);

		void Update(int airlineId,
		            ApiAirTransportModel model);

		void Delete(int airlineId);

		POCOAirTransport Get(int airlineId);

		List<POCOAirTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f323a3f86b4b64aa0b1fcf44cddc4b12</Hash>
</Codenesium>*/