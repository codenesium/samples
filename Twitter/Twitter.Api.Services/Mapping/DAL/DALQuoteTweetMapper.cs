using Microsoft.EntityFrameworkCore;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class DALQuoteTweetMapper : DALAbstractQuoteTweetMapper, IDALQuoteTweetMapper
	{
		public DALQuoteTweetMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c6afd021e27febf76399af3919a1cc83</Hash>
</Codenesium>*/