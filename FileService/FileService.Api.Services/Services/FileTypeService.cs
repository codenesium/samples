using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FileServiceNS.Api.Services
{
	public partial class FileTypeService : AbstractFileTypeService, IFileTypeService
	{
		public FileTypeService(
			ILogger<IFileTypeRepository> logger,
			IMediator mediator,
			IFileTypeRepository fileTypeRepository,
			IApiFileTypeServerRequestModelValidator fileTypeModelValidator,
			IBOLFileTypeMapper bolFileTypeMapper,
			IDALFileTypeMapper dalFileTypeMapper,
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper)
			: base(logger,
			       mediator,
			       fileTypeRepository,
			       fileTypeModelValidator,
			       bolFileTypeMapper,
			       dalFileTypeMapper,
			       bolFileMapper,
			       dalFileMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ce49d12f7f7ce72d95aff84412da3bf3</Hash>
</Codenesium>*/