using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>bf50b8a1c421a3d2da40dde9e0877d7b</Hash>
</Codenesium>*/