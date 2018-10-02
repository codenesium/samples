using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class DALUserMapper : DALAbstractUserMapper, IDALUserMapper
	{
		public DALUserMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>5ee3c65e8e96c37eab69d34bbf8a954f</Hash>
</Codenesium>*/