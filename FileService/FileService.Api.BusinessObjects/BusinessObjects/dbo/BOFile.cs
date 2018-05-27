using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public class BOFile:AbstractBOFile, IBOFile
	{
		public BOFile(
			ILogger<FileRepository> logger,
			IFileRepository fileRepository,
			IApiFileRequestModelValidator fileModelValidator,
			IBOLFileMapper fileMapper)
			: base(logger, fileRepository, fileModelValidator, fileMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>d98e116a200915b65d06228a05b8d3e8</Hash>
</Codenesium>*/