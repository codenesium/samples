using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class DALVotesMapper : DALAbstractVotesMapper, IDALVotesMapper
	{
		public DALVotesMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>e48e132b046ca469f5ba68dc12457829</Hash>
</Codenesium>*/