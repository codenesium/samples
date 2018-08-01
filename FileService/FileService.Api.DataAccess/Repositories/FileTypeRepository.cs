using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>cc342e1530b6ea7f18992511a5652b2e</Hash>
</Codenesium>*/