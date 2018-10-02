using Microsoft.EntityFrameworkCore;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class DALRetweetMapper : DALAbstractRetweetMapper, IDALRetweetMapper
	{
		public DALRetweetMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>25d364673c5b8c0a09e30f33d68e27b4</Hash>
</Codenesium>*/