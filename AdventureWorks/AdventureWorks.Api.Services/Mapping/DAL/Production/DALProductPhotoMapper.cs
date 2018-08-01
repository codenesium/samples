using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALProductPhotoMapper : DALAbstractProductPhotoMapper, IDALProductPhotoMapper
	{
		public DALProductPhotoMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8cde0e2d8658e096deae1b78f4053fa5</Hash>
</Codenesium>*/