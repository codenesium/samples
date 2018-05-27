using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICultureRepository
	{
		Task<DTOCulture> Create(DTOCulture dto);

		Task Update(string cultureID,
		            DTOCulture dto);

		Task Delete(string cultureID);

		Task<DTOCulture> Get(string cultureID);

		Task<List<DTOCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOCulture> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>98cd15070a606d4d7eacaeb62c146d18</Hash>
</Codenesium>*/