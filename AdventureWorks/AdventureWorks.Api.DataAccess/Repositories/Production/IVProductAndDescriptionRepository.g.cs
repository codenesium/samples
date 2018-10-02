using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IVProductAndDescriptionRepository
	{
		Task<VProductAndDescription> Create(VProductAndDescription item);

		Task Update(VProductAndDescription item);

		Task Delete(string cultureID);

		Task<VProductAndDescription> Get(string cultureID);

		Task<List<VProductAndDescription>> All(int limit = int.MaxValue, int offset = 0);

		Task<VProductAndDescription> ByCultureIDProductID(string cultureID, int productID);
	}
}

/*<Codenesium>
    <Hash>602c74788e7a49078e150b5be8030c03</Hash>
</Codenesium>*/