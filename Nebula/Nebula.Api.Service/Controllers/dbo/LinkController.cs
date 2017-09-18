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
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Service
{
	[RoutePrefix("api/links")]
	public class LinksController: LinksControllerAbstract
	{
		public LinksController(
			ILogger logger,
			DbContext context,
			LinkRepository linkRepository,
			LinkModelValidator linkModelValidator
			) : base(logger,
			         context,
			         linkRepository,
			         linkModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ff0ce79ceb596cc79b3c9fe1f17e6b16</Hash>
</Codenesium>*/