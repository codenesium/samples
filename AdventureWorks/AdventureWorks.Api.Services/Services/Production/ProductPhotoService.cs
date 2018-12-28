using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductPhotoService : AbstractProductPhotoService, IProductPhotoService
	{
		public ProductPhotoService(
			ILogger<IProductPhotoRepository> logger,
			IMediator mediator,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoServerRequestModelValidator productPhotoModelValidator,
			IBOLProductPhotoMapper bolProductPhotoMapper,
			IDALProductPhotoMapper dalProductPhotoMapper)
			: base(logger,
			       mediator,
			       productPhotoRepository,
			       productPhotoModelValidator,
			       bolProductPhotoMapper,
			       dalProductPhotoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>abc011d09b5a1770181bd405962c5533</Hash>
</Codenesium>*/