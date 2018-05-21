using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentRepository
	{
		Task<POCOStudent> Create(ApiStudentModel model);

		Task Update(int id,
		            ApiStudentModel model);

		Task Delete(int id);

		Task<POCOStudent> Get(int id);

		Task<List<POCOStudent>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>91206ebab19fba2778234e41f5000d6f</Hash>
</Codenesium>*/