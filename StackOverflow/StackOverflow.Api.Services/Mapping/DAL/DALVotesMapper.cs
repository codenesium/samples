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
    <Hash>ce57bca86f831e96d34cd63ebf3f03e4</Hash>
</Codenesium>*/