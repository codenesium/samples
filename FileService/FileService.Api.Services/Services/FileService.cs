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
			IDALFileMapper dalfileMapper)
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
    <Hash>725baded7ac818de3f4e247121c12ef9</Hash>
</Codenesium>*/