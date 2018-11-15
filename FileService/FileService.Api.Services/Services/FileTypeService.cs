using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace FileServiceNS.Api.Services
{
	public partial class FileTypeService : AbstractFileTypeService, IFileTypeService
	{
		public FileTypeService(
			ILogger<IFileTypeRepository> logger,
			IFileTypeRepository fileTypeRepository,
			IApiFileTypeServerRequestModelValidator fileTypeModelValidator,
			IBOLFileTypeMapper bolFileTypeMapper,
			IDALFileTypeMapper dalFileTypeMapper,
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper)
			: base(logger,
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
    <Hash>6dc26f4799527b1251b668cc6506ad5b</Hash>
</Codenesium>*/