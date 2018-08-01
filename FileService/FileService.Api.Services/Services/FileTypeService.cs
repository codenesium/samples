using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
			IDALFileMapper dalFileMapper
			)
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
    <Hash>ddd564ae5b9a04d8222446431e15ad1c</Hash>
</Codenesium>*/