using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
	public class FileTypeRepository: AbstractFileTypeRepository, IFileTypeRepository
	{
		public FileTypeRepository(
			ILogger<FileTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>8ebcff0e5b6fcac0bd4bf272b2e06ba0</Hash>
</Codenesium>*/