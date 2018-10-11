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
	}
}

/*<Codenesium>
    <Hash>0ff11c0f147dd40564a4473bf5ae4d65</Hash>
</Codenesium>*/