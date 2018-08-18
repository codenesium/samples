using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class DALCommentsMapper : DALAbstractCommentsMapper, IDALCommentsMapper
	{
		public DALCommentsMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>b9a5361847f14cb9c48ca3e5bef84837</Hash>
</Codenesium>*/