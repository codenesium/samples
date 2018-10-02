using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class DALVoteTypeMapper : DALAbstractVoteTypeMapper, IDALVoteTypeMapper
	{
		public DALVoteTypeMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>539b7cf2540138fb55373d70a8c86186</Hash>
</Codenesium>*/