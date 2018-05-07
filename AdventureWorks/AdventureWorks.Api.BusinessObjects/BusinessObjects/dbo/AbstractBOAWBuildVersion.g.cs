using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOAWBuildVersion
	{
		private IAWBuildVersionRepository aWBuildVersionRepository;
		private IAWBuildVersionModelValidator aWBuildVersionModelValidator;
		private ILogger logger;

		public AbstractBOAWBuildVersion(
			ILogger logger,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IAWBuildVersionModelValidator aWBuildVersionModelValidator)

		{
			this.aWBuildVersionRepository = aWBuildVersionRepository;
			this.aWBuildVersionModelValidator = aWBuildVersionModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			AWBuildVersionModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.aWBuildVersionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.aWBuildVersionRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int systemInformationID,
			AWBuildVersionModel model)
		{
			ActionResponse response = new ActionResponse(await this.aWBuildVersionModelValidator.ValidateUpdateAsync(systemInformationID, model));

			if (response.Success)
			{
				this.aWBuildVersionRepository.Update(systemInformationID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int systemInformationID)
		{
			ActionResponse response = new ActionResponse(await this.aWBuildVersionModelValidator.ValidateDeleteAsync(systemInformationID));

			if (response.Success)
			{
				this.aWBuildVersionRepository.Delete(systemInformationID);
			}
			return response;
		}

		public virtual POCOAWBuildVersion Get(int systemInformationID)
		{
			return this.aWBuildVersionRepository.Get(systemInformationID);
		}

		public virtual List<POCOAWBuildVersion> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.aWBuildVersionRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>64de53aa99aab2fd7b2069f1dca0691b</Hash>
</Codenesium>*/