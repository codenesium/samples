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
	public class BOFileType: AbstractBOFileType, IBOFileType
	{
		public BOFileType(
			ILogger<FileTypeRepository> logger,
			IFileTypeRepository fileTypeRepository,
			IApiFileTypeRequestModelValidator fileTypeModelValidator,
			IBOLFileTypeMapper fileTypeMapper)
			: base(logger, fileTypeRepository, fileTypeModelValidator, fileTypeMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>11fbd8eef8eaca5eac90edf51030fcbf</Hash>
</Codenesium>*/