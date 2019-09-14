using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IUnitOfficerRepository
	{
		Task<UnitOfficer> Create(UnitOfficer item);

		Task Update(UnitOfficer item);

		Task Delete(int id);

		Task<UnitOfficer> Get(int id);

		Task<List<UnitOfficer>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Officer> OfficerByOfficerId(int officerId);

		Task<Unit> UnitByUnitId(int unitId);
	}
}

/*<Codenesium>
    <Hash>f1693acb75566ae997f6f2751da7c29b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/