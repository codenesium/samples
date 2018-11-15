using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductPhotoService : AbstractProductPhotoService, IProductPhotoService
	{
		public ProductPhotoService(
			ILogger<IProductPhotoRepository> logger,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoServerRequestModelValidator productPhotoModelValidator,
			IBOLProductPhotoMapper bolProductPhotoMapper,
			IDALProductPhotoMapper dalProductPhotoMapper)
			: base(logger,
			       productPhotoRepository,
			       productPhotoModelValidator,
			       bolProductPhotoMapper,
			       dalProductPhotoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>fe2a390060e4c03f31cb0bf34d053390</Hash>
</Codenesium>*/