using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public class FileTypeRepository: AbstractFileTypeRepository, IFileTypeRepository
	{
		public FileTypeRepository(
			IDALFileTypeMapper mapper,
			ILogger<FileTypeRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>ce7878e8b38b0d6669fa319904fa58c9</Hash>
</Codenesium>*/