using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ICultureRepository
	{
		Task<Culture> Create(Culture item);

		Task Update(Culture item);

		Task Delete(string cultureID);

		Task<Culture> Get(string cultureID);

		Task<List<Culture>> All(int limit = int.MaxValue, int offset = 0);

		Task<Culture> ByName(string name);

		Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultures(string cultureID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1c063b9a1320c90c373fbbe93127c475</Hash>
</Codenesium>*/