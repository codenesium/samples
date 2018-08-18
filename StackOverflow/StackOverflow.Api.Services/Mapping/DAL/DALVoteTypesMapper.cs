using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class DALVoteTypesMapper : DALAbstractVoteTypesMapper, IDALVoteTypesMapper
	{
		public DALVoteTypesMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>dedeecbeb4217d80fa277678c6c40ff5</Hash>
</Codenesium>*/