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
			IFileModelValidator fileModelValidator)
			: base(logger, fileRepository, fileModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e427bbc5d0aa693c795f6cdee1d53878</Hash>
</Codenesium>*/