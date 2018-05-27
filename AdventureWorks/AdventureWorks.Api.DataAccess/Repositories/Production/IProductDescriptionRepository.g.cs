using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDescriptionRepository
	{
		Task<DTOProductDescription> Create(DTOProductDescription dto);

		Task Update(int productDescriptionID,
		            DTOProductDescription dto);

		Task Delete(int productDescriptionID);

		Task<DTOProductDescription> Get(int productDescriptionID);

		Task<List<DTOProductDescription>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f7defc392f769322cdb58658ec6608d3</Hash>
</Codenesium>*/