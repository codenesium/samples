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

		Task<List<ProductModelIllustration>> ProductModelIllustrations(int illustrationID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c983e1ebd603016a3f6bf5f7e652c61a</Hash>
</Codenesium>*/