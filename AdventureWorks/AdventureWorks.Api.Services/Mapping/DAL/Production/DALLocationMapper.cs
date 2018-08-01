using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALLocationMapper : DALAbstractLocationMapper, IDALLocationMapper
	{
		public DALLocationMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>591e7d0f9bcd6039607191dcc8a45cb9</Hash>
</Codenesium>*/