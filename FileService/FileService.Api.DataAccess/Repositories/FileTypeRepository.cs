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
	public partial class FileTypeRepository : AbstractFileTypeRepository, IFileTypeRepository
	{
		public FileTypeRepository(
			ILogger<FileTypeRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>ed8f392d5fee982ad7d1b5b3a1895d5e</Hash>
</Codenesium>*/