using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class EventTeacherService : AbstractEventTeacherService, IEventTeacherService
	{
		public EventTeacherService(
			ILogger<IEventTeacherRepository> logger,
			IEventTeacherRepository eventTeacherRepository,
			IApiEventTeacherRequestModelValidator eventTeacherModelValidator,
			IBOLEventTeacherMapper boleventTeacherMapper,
			IDALEventTeacherMapper daleventTeacherMapper
			)
			: base(logger,
			       eventTeacherRepository,
			       eventTeacherModelValidator,
			       boleventTeacherMapper,
			       daleventTeacherMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>40b65c41ad006df80d0c66e21452a699</Hash>
</Codenesium>*/