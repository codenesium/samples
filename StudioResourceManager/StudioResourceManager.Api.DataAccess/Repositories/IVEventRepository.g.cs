using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.DataAccess
{
	public partial interface IVEventRepository
	{
		Task<VEvent> Create(VEvent item);

		Task Update(VEvent item);

		Task Delete(int id);

		Task<VEvent> Get(int id);

		Task<List<VEvent>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>99f333070481f97cab523f4c602af694</Hash>
</Codenesium>*/