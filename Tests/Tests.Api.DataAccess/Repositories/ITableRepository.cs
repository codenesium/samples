using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface ITableRepository
	{
		Task<Table> Create(Table item);

		Task Update(Table item);

		Task Delete(int id);

		Task<Table> Get(int id);

		Task<List<Table>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>d38fd05ebdc1c40955bf69190ba92567</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/