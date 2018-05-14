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
			IApiFileModelValidator fileModelValidator)
			: base(logger, fileRepository, fileModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>b4c7a59f0a2e0b4d837f10e6b456a499</Hash>
</Codenesium>*/