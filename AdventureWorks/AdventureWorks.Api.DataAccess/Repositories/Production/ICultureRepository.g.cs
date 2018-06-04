using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICultureRepository
	{
		Task<Culture> Create(Culture item);

		Task Update(Culture item);

		Task Delete(string cultureID);

		Task<Culture> Get(string cultureID);

		Task<List<Culture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<Culture> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>7dffdf7fae12ec741946604f9ec00443</Hash>
</Codenesium>*/