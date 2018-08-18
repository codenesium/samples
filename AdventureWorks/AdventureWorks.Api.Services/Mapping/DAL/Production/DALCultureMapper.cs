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
    <Hash>5097e488062aec4341c54ccbae30c1c6</Hash>
</Codenesium>*/