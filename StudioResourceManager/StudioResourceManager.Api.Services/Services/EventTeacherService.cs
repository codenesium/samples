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
			IDALEventTeacherMapper daleventTeacherMapper)
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
    <Hash>0a0438e4363b3e3332fddec4a2d46235</Hash>
</Codenesium>*/