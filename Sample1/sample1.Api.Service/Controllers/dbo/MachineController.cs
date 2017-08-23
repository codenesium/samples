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
using sample1NS.Api.Contracts;
using sample1NS.Api.DataAccess;
namespace sample1NS.Api.Service
{
	[RoutePrefix("api/machines")]
	public class MachineController: MachineControllerAbstract
	{
		public MachineController(
			ILogger logger,
			DbContext context,
			MachineRepository machineRepository,
			MachineModelValidator machineModelValidator
			) : base(logger,
			         context,
			         machineRepository,
			         machineModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>00e589f21dcd2eca24d35712b453f4b6</Hash>
</Codenesium>*/