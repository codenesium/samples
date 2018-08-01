using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
	public partial class TagSetService : AbstractTagSetService, ITagSetService
	{
		public TagSetService(
			ILogger<ITagSetRepository> logger,
			ITagSetRepository tagSetRepository,
			IApiTagSetRequestModelValidator tagSetModelValidator,
			IBOLTagSetMapper boltagSetMapper,
			IDALTagSetMapper daltagSetMapper
			)
			: base(logger,
			       tagSetRepository,
			       tagSetModelValidator,
			       boltagSetMapper,
			       daltagSetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>014897879a3e6f6434bfc77adc26e9c7</Hash>
</Codenesium>*/