using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALCultureMapper : DALAbstractCultureMapper, IDALCultureMapper
	{
		public DALCultureMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>61e0925276963df67517d0319eee1464</Hash>
</Codenesium>*/