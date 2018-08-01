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
    <Hash>ba3d13b590f0bc5f4685a50111a23ff2</Hash>
</Codenesium>*/