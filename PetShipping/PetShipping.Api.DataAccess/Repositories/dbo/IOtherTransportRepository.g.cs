using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IOtherTransportRepository
	{
		POCOOtherTransport Create(OtherTransportModel model);

		void Update(int id,
		            OtherTransportModel model);

		void Delete(int id);

		POCOOtherTransport Get(int id);

		List<POCOOtherTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>43fe129411483df9248af3f694c7e252</Hash>
</Codenesium>*/