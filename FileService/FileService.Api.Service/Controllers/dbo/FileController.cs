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
	[RoutePrefix("api/files")]
	public class FilesController: FilesControllerAbstract
	{
		public FilesController(
			ILogger logger,
			DbContext context,
			FileRepository fileRepository,
			FileModelValidator fileModelValidator
			) : base(logger,
			         context,
			         fileRepository,
			         fileModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>ab8ccf601b2ac9c7c073753abb03ce18</Hash>
</Codenesium>*/