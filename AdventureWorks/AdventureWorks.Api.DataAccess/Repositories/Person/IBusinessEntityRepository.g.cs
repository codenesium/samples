using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityRepository
	{
		Task<DTOBusinessEntity> Create(DTOBusinessEntity dto);

		Task Update(int businessEntityID,
		            DTOBusinessEntity dto);

		Task Delete(int businessEntityID);

		Task<DTOBusinessEntity> Get(int businessEntityID);

		Task<List<DTOBusinessEntity>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9dad0a24956091ae059bb7c99a608d6b</Hash>
</Codenesium>*/