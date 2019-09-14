using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IUnitDispositionRepository
	{
		Task<UnitDisposition> Create(UnitDisposition item);

		Task Update(UnitDisposition item);

		Task Delete(int id);

		Task<UnitDisposition> Get(int id);

		Task<List<UnitDisposition>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>121fc603e85c15a85972d71ea9e6c55f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/