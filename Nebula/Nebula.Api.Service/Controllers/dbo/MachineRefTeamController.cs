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
	[RoutePrefix("api/machineRefTeams")]
	public class MachineRefTeamsController: MachineRefTeamsControllerAbstract
	{
		public MachineRefTeamsController(
			ILogger logger,
			DbContext context,
			MachineRefTeamRepository machineRefTeamRepository,
			MachineRefTeamModelValidator machineRefTeamModelValidator
			) : base(logger,
			         context,
			         machineRefTeamRepository,
			         machineRefTeamModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ac11503e123547bd7f43de4d4b1d1eb5</Hash>
</Codenesium>*/