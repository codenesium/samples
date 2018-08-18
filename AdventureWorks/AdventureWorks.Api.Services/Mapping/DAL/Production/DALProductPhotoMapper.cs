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
    <Hash>2e4c2330bf565d7d2c9129fcc9eb773d</Hash>
</Codenesium>*/