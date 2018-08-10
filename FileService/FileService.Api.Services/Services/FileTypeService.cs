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
    <Hash>4b1b19b02b519247c1899067eae6d7b5</Hash>
</Codenesium>*/