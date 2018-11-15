using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace FileServiceNS.Api.Services
{
	public partial class FileService : AbstractFileService, IFileService
	{
		public FileService(
			ILogger<IFileRepository> logger,
			IFileRepository fileRepository,
			IApiFileServerRequestModelValidator fileModelValidator,
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper)
			: base(logger,
			       fileRepository,
			       fileModelValidator,
			       bolFileMapper,
			       dalFileMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ba17e1646bacd72a7cf07c2eacd529d5</Hash>
</Codenesium>*/