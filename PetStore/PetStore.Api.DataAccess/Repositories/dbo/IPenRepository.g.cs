using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public interface IPenRepository
	{
		Task<POCOPen> Create(ApiPenModel model);

		Task Update(int id,
		            ApiPenModel model);

		Task Delete(int id);

		Task<POCOPen> Get(int id);

		Task<List<POCOPen>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>709228dd539b7e238c50d480dfb5f02f</Hash>
</Codenesium>*/