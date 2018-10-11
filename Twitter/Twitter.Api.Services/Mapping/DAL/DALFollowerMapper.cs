using Microsoft.EntityFrameworkCore;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class DALFollowerMapper : DALAbstractFollowerMapper, IDALFollowerMapper
	{
		public DALFollowerMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1474526c36ae7674bbf6510e8b0260ec</Hash>
</Codenesium>*/