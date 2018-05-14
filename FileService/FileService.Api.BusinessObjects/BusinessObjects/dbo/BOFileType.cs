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
			IApiFileTypeModelValidator fileTypeModelValidator)
			: base(logger, fileTypeRepository, fileTypeModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>0bdb39b7750131c8c721c900d35fe47a</Hash>
</Codenesium>*/