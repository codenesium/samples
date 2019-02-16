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
			IDALFileTypeMapper dalFileTypeMapper,
			IDALFileMapper dalFileMapper)
			: base(logger,
			       mediator,
			       fileTypeRepository,
			       fileTypeModelValidator,
			       dalFileTypeMapper,
			       dalFileMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ca88048bdaaff66004248062601f903e</Hash>
</Codenesium>*/