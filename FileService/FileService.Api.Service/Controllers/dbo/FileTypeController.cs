using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service
{
	[RoutePrefix("api/fileTypes")]
	public class FileTypesController: FileTypesControllerAbstract
	{
		public FileTypesController(
			ILogger logger,
			DbContext context,
			FileTypeRepository fileTypeRepository,
			FileTypeModelValidator fileTypeModelValidator
			) : base(logger,
			         context,
			         fileTypeRepository,
			         fileTypeModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5db54371fb5dca6f969bdb0dc3cfec50</Hash>
</Codenesium>*/