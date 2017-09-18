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
	[RoutePrefix("api/machines")]
	public class MachinesController: MachinesControllerAbstract
	{
		public MachinesController(
			ILogger logger,
			DbContext context,
			MachineRepository machineRepository,
			MachineModelValidator machineModelValidator
			) : base(logger,
			         context,
			         machineRepository,
			         machineModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>85b4eccebbbb30d50746d2f665f128d0</Hash>
</Codenesium>*/