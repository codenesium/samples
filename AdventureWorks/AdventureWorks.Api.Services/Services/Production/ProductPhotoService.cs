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
			IDALProductPhotoMapper dalProductPhotoMapper)
			: base(logger,
			       mediator,
			       productPhotoRepository,
			       productPhotoModelValidator,
			       dalProductPhotoMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>125973b045446eba176327a737aaa94e</Hash>
</Codenesium>*/