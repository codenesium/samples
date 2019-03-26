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
			IDALProductPhotoMapper dalProductPhotoMapper,
			IDALProductProductPhotoMapper dalProductProductPhotoMapper)
			: base(logger,
			       mediator,
			       productPhotoRepository,
			       productPhotoModelValidator,
			       dalProductPhotoMapper,
			       dalProductProductPhotoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>328a04c248aef55c1d98b8579a5c5e0e</Hash>
</Codenesium>*/