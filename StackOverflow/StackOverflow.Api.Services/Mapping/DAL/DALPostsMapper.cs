using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class DALPostsMapper : DALAbstractPostsMapper, IDALPostsMapper
	{
		public DALPostsMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7929feeb7b36b0bf055671e177a7124d</Hash>
</Codenesium>*/