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
	public class FileService: AbstractFileService, IFileService
	{
		public FileService(
			ILogger<FileRepository> logger,
			IFileRepository fileRepository,
			IApiFileRequestModelValidator fileModelValidator,
			IBOLFileMapper BOLfileMapper,
			IDALFileMapper DALfileMapper)
			: base(logger, fileRepository,
			       fileModelValidator,
			       BOLfileMapper,
			       DALfileMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>142eacd02e1e84a03faae18ec4023d7c</Hash>
</Codenesium>*/