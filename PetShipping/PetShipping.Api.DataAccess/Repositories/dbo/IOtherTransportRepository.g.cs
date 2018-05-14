using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IOtherTransportRepository
	{
		POCOOtherTransport Create(ApiOtherTransportModel model);

		void Update(int id,
		            ApiOtherTransportModel model);

		void Delete(int id);

		POCOOtherTransport Get(int id);

		List<POCOOtherTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>766691fe34e2c68a6a6a2b77ca348479</Hash>
</Codenesium>*/