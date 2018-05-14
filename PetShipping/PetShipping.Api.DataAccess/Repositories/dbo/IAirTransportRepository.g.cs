using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirTransportRepository
	{
		POCOAirTransport Create(AirTransportModel model);

		void Update(int airlineId,
		            AirTransportModel model);

		void Delete(int airlineId);

		POCOAirTransport Get(int airlineId);

		List<POCOAirTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>174aa2ae17dcf6d54d48f7f65e2c64ca</Hash>
</Codenesium>*/