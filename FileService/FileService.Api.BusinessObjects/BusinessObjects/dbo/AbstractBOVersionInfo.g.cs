using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public abstract class AbstractBOVersionInfo
	{
		private IVersionInfoRepository versionInfoRepository;
		private IApiVersionInfoModelValidator versionInfoModelValidator;
		private ILogger logger;

		public AbstractBOVersionInfo(
			ILogger logger,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoModelValidator versionInfoModelValidator)

		{
			this.versionInfoRepository = versionInfoRepository;
			this.versionInfoModelValidator = versionInfoModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOVersionInfo> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.versionInfoRepository.All(skip, take, orderClause);
		}

		public virtual POCOVersionInfo Get(long version)
		{
			return this.versionInfoRepository.Get(version);
		}

		public virtual async Task<CreateResponse<POCOVersionInfo>> Create(
			ApiVersionInfoModel model)
		{
			CreateResponse<POCOVersionInfo> response = new CreateResponse<POCOVersionInfo>(await this.versionInfoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOVersionInfo record = this.versionInfoRepository.Create(model);
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

		public POCOVersionInfo Version(long version)
		{
			return this.versionInfoRepository.Version(version);
		}
	}
}

/*<Codenesium>
    <Hash>3ad5aa54580b73dfa0db67a4e20b6afa</Hash>
</Codenesium>*/