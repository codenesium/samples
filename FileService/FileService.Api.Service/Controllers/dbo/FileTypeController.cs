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
		{}
	}
}

/*<Codenesium>
    <Hash>454711cca2406e63de4ee84ff3c8b4df</Hash>
</Codenesium>*/