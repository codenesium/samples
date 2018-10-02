using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class DALVoteMapper : DALAbstractVoteMapper, IDALVoteMapper
	{
		public DALVoteMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>dea00b80ccb060e1608a4ef7c00856fe</Hash>
</Codenesium>*/