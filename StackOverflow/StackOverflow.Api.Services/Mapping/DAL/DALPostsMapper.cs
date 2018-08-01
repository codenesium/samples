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
    <Hash>53de804694f484b5f54d693d761d95fb</Hash>
</Codenesium>*/