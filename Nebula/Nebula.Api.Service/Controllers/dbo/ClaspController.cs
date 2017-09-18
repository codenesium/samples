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
	[RoutePrefix("api/clasps")]
	public class ClaspsController: ClaspsControllerAbstract
	{
		public ClaspsController(
			ILogger logger,
			DbContext context,
			ClaspRepository claspRepository,
			ClaspModelValidator claspModelValidator
			) : base(logger,
			         context,
			         claspRepository,
			         claspModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f24b456265b5a3cef8b19b55290c48ff</Hash>
</Codenesium>*/