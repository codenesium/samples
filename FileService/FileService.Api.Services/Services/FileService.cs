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
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper)
			: base(logger,
			       mediator,
			       fileRepository,
			       fileModelValidator,
			       bolFileMapper,
			       dalFileMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>cb3310374ac8fee57e7687a5218b8db5</Hash>
</Codenesium>*/