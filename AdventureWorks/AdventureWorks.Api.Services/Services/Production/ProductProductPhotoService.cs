using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductProductPhotoService : AbstractProductProductPhotoService, IProductProductPhotoService
	{
		public ProductProductPhotoService(
			ILogger<IProductProductPhotoRepository> logger,
			IMediator mediator,
			IProductProductPhotoRepository productProductPhotoRepository,
			IApiProductProductPhotoServerRequestModelValidator productProductPhotoModelValidator,
			IDALProductProductPhotoMapper dalProductProductPhotoMapper)
			: base(logger,
			       mediator,
			       productProductPhotoRepository,
			       productProductPhotoModelValidator,
			       dalProductProductPhotoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>13df232f2cd8e361eb35a37738d0711a</Hash>
</Codenesium>*/