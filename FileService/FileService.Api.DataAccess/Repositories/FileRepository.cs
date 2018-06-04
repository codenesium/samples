using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
	public class FileRepository: AbstractFileRepository, IFileRepository
	{
		public FileRepository(
			ILogger<FileRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>552e29e943c42b01627480d744beacc3</Hash>
</Codenesium>*/