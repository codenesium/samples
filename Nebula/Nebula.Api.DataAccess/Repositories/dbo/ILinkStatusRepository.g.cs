using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkStatusRepository
	{
		Task<POCOLinkStatus> Create(ApiLinkStatusModel model);

		Task Update(int id,
		            ApiLinkStatusModel model);

		Task Delete(int id);

		Task<POCOLinkStatus> Get(int id);

		Task<List<POCOLinkStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOLinkStatus> Name(string name);
	}
}

/*<Codenesium>
    <Hash>22f4deab2cd3d1d8c22acf9ca9b06ed6</Hash>
</Codenesium>*/