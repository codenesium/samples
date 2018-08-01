using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
	public partial class FileRepository : AbstractFileRepository, IFileRepository
	{
		public FileRepository(
			ILogger<FileRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>720d6185e96b340f8169ac6fb46a9f33</Hash>
</Codenesium>*/