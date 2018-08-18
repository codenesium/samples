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
    <Hash>95efce904b0f28485aa40d0a3b08e82f</Hash>
</Codenesium>*/