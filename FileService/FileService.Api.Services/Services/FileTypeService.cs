using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
	public class FileTypeService: AbstractFileTypeService, IFileTypeService
	{
		public FileTypeService(
			ILogger<FileTypeRepository> logger,
			IFileTypeRepository fileTypeRepository,
			IApiFileTypeRequestModelValidator fileTypeModelValidator,
			IBOLFileTypeMapper BOLfileTypeMapper,
			IDALFileTypeMapper DALfileTypeMapper)
			: base(logger, fileTypeRepository,
			       fileTypeModelValidator,
			       BOLfileTypeMapper,
			       DALfileTypeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>978d6dba293b58b0ac3d48cd3897c434</Hash>
</Codenesium>*/