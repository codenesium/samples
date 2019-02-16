using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FileServiceNS.Api.Services
{
	public partial class FileService : AbstractFileService, IFileService
	{
		public FileService(
			ILogger<IFileRepository> logger,
			IMediator mediator,
			IFileRepository fileRepository,
			IApiFileServerRequestModelValidator fileModelValidator,
			IDALFileMapper dalFileMapper)
			: base(logger,
			       mediator,
			       fileRepository,
			       fileModelValidator,
			       dalFileMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>1220e94f499c7b314a8ecdd36d0ce0ba</Hash>
</Codenesium>*/