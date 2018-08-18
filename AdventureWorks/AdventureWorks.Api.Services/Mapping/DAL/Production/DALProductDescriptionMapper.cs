using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductDescriptionMapper : DALAbstractProductDescriptionMapper, IDALProductDescriptionMapper
	{
		public DALProductDescriptionMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>44593d5eacdcfe5fabe7f6a7dee52b42</Hash>
</Codenesium>*/