using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
{
	public partial interface IEfmigrationshistoryRepository
	{
		Task<Efmigrationshistory> Create(Efmigrationshistory item);

		Task Update(Efmigrationshistory item);

		Task Delete(string migrationId);

		Task<Efmigrationshistory> Get(string migrationId);

		Task<List<Efmigrationshistory>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3b9e57f4a551f89f68acc282380f3f20</Hash>
</Codenesium>*/