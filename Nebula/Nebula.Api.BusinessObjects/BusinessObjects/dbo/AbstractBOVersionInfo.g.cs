using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOVersionInfo
	{
		private IVersionInfoRepository versionInfoRepository;
		private IVersionInfoModelValidator versionInfoModelValidator;
		private ILogger logger;

		public AbstractBOVersionInfo(
			ILogger logger,
			IVersionInfoRepository versionInfoRepository,
			IVersionInfoModelValidator versionInfoModelValidator)

		{
			this.versionInfoRepository = versionInfoRepository;
			this.versionInfoModelValidator = versionInfoModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<long>> Create(
			VersionInfoModel model)
		{
			CreateResponse<long> response = new CreateResponse<long>(await this.versionInfoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				long id = this.versionInfoRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			long version,
			VersionInfoModel model)
		{
			ActionResponse response = new ActionResponse(await this.versionInfoModelValidator.ValidateUpdateAsync(version, model));

			if (response.Success)
			{
				this.versionInfoRepository.Update(version, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			long version)
		{
			ActionResponse response = new ActionResponse(await this.versionInfoModelValidator.ValidateDeleteAsync(version));

			if (response.Success)
			{
				this.versionInfoRepository.Delete(version);
			}
			return response;
		}

		public virtual POCOVersionInfo Get(long version)
		{
			return this.versionInfoRepository.Get(version);
		}

		public virtual List<POCOVersionInfo> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.versionInfoRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>190ce22505e2fa5dde9b118bdb3094b9</Hash>
</Codenesium>*/