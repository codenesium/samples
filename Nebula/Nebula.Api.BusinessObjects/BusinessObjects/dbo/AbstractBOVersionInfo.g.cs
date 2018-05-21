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
	public abstract class AbstractBOVersionInfo: AbstractBOManager
	{
		private IVersionInfoRepository versionInfoRepository;
		private IApiVersionInfoModelValidator versionInfoModelValidator;
		private ILogger logger;

		public AbstractBOVersionInfo(
			ILogger logger,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoModelValidator versionInfoModelValidator)
			: base()

		{
			this.versionInfoRepository = versionInfoRepository;
			this.versionInfoModelValidator = versionInfoModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOVersionInfo>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.versionInfoRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOVersionInfo> Get(long version)
		{
			return this.versionInfoRepository.Get(version);
		}

		public virtual async Task<CreateResponse<POCOVersionInfo>> Create(
			ApiVersionInfoModel model)
		{
			CreateResponse<POCOVersionInfo> response = new CreateResponse<POCOVersionInfo>(await this.versionInfoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOVersionInfo record = await this.versionInfoRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			long version,
			ApiVersionInfoModel model)
		{
			ActionResponse response = new ActionResponse(await this.versionInfoModelValidator.ValidateUpdateAsync(version, model));

			if (response.Success)
			{
				await this.versionInfoRepository.Update(version, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			long version)
		{
			ActionResponse response = new ActionResponse(await this.versionInfoModelValidator.ValidateDeleteAsync(version));

			if (response.Success)
			{
				await this.versionInfoRepository.Delete(version);
			}
			return response;
		}

		public async Task<POCOVersionInfo> Version(long version)
		{
			return await this.versionInfoRepository.Version(version);
		}
	}
}

/*<Codenesium>
    <Hash>14c0e211c2f20b351d9cc154f14457e1</Hash>
</Codenesium>*/