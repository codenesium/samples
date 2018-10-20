using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IIllustrationRepository
	{
		Task<Illustration> Create(Illustration item);

		Task Update(Illustration item);

		Task Delete(int illustrationID);

		Task<Illustration> Get(int illustrationID);

		Task<List<Illustration>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Illustration>> ByProductModelID(int productModelID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e9f5a3dd2f3c06095e7c12e6af11438a</Hash>
</Codenesium>*/