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
	[RoutePrefix("api/machineRefTeams")]
	public class MachineRefTeamController: MachineRefTeamControllerAbstract
	{
		public MachineRefTeamController(
			ILogger logger,
			DbContext context,
			MachineRefTeamRepository machineRefTeamRepository,
			MachineRefTeamModelValidator machineRefTeamModelValidator
			) : base(logger,
			         context,
			         machineRefTeamRepository,
			         machineRefTeamModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>ddd995b7c535317371c51b296020492b</Hash>
</Codenesium>*/