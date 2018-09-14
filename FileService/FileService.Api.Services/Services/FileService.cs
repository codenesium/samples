using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
    public partial class FileService : AbstractFileService, IFileService
    {
        public FileService(
			ILogger<IFileRepository> logger,
			  IFileRepository fileRepository,
			  IApiFileRequestModelValidator fileModelValidator,
			  IBOLFileMapper bolfileMapper,
			  IDALFileMapper dalfileMapper			  
			  )
			: base(logger, 
			fileRepository, 
			fileModelValidator, 
			bolfileMapper,
			dalfileMapper)
        {

        }
    }
}

/*<Codenesium>
    <Hash>e5d8e00e2731ef1baddb16c958b94ce0</Hash>
</Codenesium>*/