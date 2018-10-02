using Microsoft.EntityFrameworkCore;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class DALFollowingMapper : DALAbstractFollowingMapper, IDALFollowingMapper
	{
		public DALFollowingMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a8e0daee08a7f271d12a41ab8f242238</Hash>
</Codenesium>*/