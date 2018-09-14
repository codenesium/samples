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
	public partial class FileService : AbstractFileService, IFileService
	{
		public FileService(
			ILogger<IFileRepository> logger,
			IFileRepository fileRepository,
			IApiFileRequestModelValidator fileModelValidator,
			IBOLFileMapper bolfileMapper,
			IDALFileMapper dalfileMapper
			)
			: base(logger,
			       fileRepository,
			       fileModelValidator,
			       bolfileMapper,
			       dalfileMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>559d5b7fd27c5ab814f8a879bbfaf3f7</Hash>
</Codenesium>*/