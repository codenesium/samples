using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IOtherTransportRepository
	{
		Task<OtherTransport> Create(OtherTransport item);

		Task Update(OtherTransport item);

		Task Delete(int id);

		Task<OtherTransport> Get(int id);

		Task<List<OtherTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>725d58bf874c8e755e902be53b867cef</Hash>
</Codenesium>*/