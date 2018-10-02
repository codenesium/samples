using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALVProductAndDescriptionMapper : DALAbstractVProductAndDescriptionMapper, IDALVProductAndDescriptionMapper
	{
		public DALVProductAndDescriptionMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8f7ed2361bf55bdbfa3282927caf2608</Hash>
</Codenesium>*/