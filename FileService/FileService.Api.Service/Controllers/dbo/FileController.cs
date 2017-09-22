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
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6d48284365089b4d00ef4814f4e4704c</Hash>
</Codenesium>*/