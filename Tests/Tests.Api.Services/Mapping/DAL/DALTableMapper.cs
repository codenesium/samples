using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class DALTableMapper : DALAbstractTableMapper, IDALTableMapper
	{
		public DALTableMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>2013fa326e8221317ec7957bdbe8626a</Hash>
</Codenesium>*/