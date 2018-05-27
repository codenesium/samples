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
	public class FileRepository: AbstractFileRepository, IFileRepository
	{
		public FileRepository(
			IDALFileMapper mapper,
			ILogger<FileRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>aaabac67178469488ccce6a70772a4f8</Hash>
</Codenesium>*/