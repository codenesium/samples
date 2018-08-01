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
    <Hash>2b2eb40777335393fb30e49453b1e565</Hash>
</Codenesium>*/