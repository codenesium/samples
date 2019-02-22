using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CADNS.Api.Services
{
	public partial class CallTypeService : AbstractCallTypeService, ICallTypeService
	{
		public CallTypeService(
			ILogger<ICallTypeRepository> logger,
			IMediator mediator,
			ICallTypeRepository callTypeRepository,
			IApiCallTypeServerRequestModelValidator callTypeModelValidator,
			IDALCallTypeMapper dalCallTypeMapper,
			IDALCallMapper dalCallMapper)
			: base(logger,
			       mediator,
			       callTypeRepository,
			       callTypeModelValidator,
			       dalCallTypeMapper,
			       dalCallMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>37fcb73bd75602c024df59bfb1f601fd</Hash>
</Codenesium>*/