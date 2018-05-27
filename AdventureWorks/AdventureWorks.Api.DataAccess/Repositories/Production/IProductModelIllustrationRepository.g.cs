using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelIllustrationRepository
	{
		Task<DTOProductModelIllustration> Create(DTOProductModelIllustration dto);

		Task Update(int productModelID,
		            DTOProductModelIllustration dto);

		Task Delete(int productModelID);

		Task<DTOProductModelIllustration> Get(int productModelID);

		Task<List<DTOProductModelIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9c1cbd27997cbf16937b52e04d9e855b</Hash>
</Codenesium>*/