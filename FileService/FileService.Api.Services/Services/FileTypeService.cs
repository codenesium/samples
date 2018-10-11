using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial class FileTypeService : AbstractFileTypeService, IFileTypeService
	{
		public FileTypeService(
			ILogger<IFileTypeRepository> logger,
			IFileTypeRepository fileTypeRepository,
			IApiFileTypeRequestModelValidator fileTypeModelValidator,
			IBOLFileTypeMapper bolfileTypeMapper,
			IDALFileTypeMapper dalfileTypeMapper,
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper)
			: base(logger,
			       fileTypeRepository,
			       fileTypeModelValidator,
			       bolfileTypeMapper,
			       dalfileTypeMapper,
			       bolFileMapper,
			       dalFileMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>29507668f4014a463bd4eed65884af6d</Hash>
</Codenesium>*/