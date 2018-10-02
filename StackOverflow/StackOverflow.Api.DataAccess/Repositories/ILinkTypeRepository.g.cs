using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.DataAccess
{
	public partial interface ILinkTypeRepository
	{
		Task<LinkType> Create(LinkType item);

		Task Update(LinkType item);

		Task Delete(int id);

		Task<LinkType> Get(int id);

		Task<List<LinkType>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5e1753010620ef2607d61b76d27975ad</Hash>
</Codenesium>*/