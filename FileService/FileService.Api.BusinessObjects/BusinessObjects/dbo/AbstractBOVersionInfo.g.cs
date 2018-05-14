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

		public virtual List<POCOVersionInfo> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.versionInfoRepository.All(skip, take, orderClause);
		}

		public virtual POCOVersionInfo Get(long version)
		{
			return this.versionInfoRepository.Get(version);
		}

		public virtual async Task<CreateResponse<POCOVersionInfo>> Create(
			VersionInfoModel model)
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

		public POCOVersionInfo Version(long version)
		{
			return this.versionInfoRepository.Version(version);
		}
	}
}

/*<Codenesium>
    <Hash>e4cb7902608b9f7020efbece4781d135</Hash>
</Codenesium>*/