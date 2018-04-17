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
			IFileTypeModelValidator fileTypeModelValidator)
			: base(logger, fileTypeRepository, fileTypeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>4f1fb90f707c76c8ade6a9df051c54b9</Hash>
</Codenesium>*/