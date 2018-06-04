using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IIllustrationRepository
	{
		Task<Illustration> Create(Illustration item);

		Task Update(Illustration item);

		Task Delete(int illustrationID);

		Task<Illustration> Get(int illustrationID);

		Task<List<Illustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6538c7417571779168760a7d7737e5fd</Hash>
</Codenesium>*/