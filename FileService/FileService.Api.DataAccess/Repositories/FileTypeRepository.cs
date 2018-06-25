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
    <Hash>497696996d68a4f3bdba6e4222fab40c</Hash>
</Codenesium>*/