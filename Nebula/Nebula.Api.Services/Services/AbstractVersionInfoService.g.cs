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

namespace NebulaNS.Api.Services
{
	public abstract class AbstractVersionInfoService: AbstractService
	{
		private IVersionInfoRepository versionInfoRepository;
		private IApiVersionInfoRequestModelValidator versionInfoModelValidator;
		private IBOLVersionInfoMapper bolVersionInfoMapper;
		private IDALVersionInfoMapper dalVersionInfoMapper;
		private ILogger logger;

		public AbstractVersionInfoService(
			ILogger logger,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoRequestModelValidator versionInfoModelValidator,
			IBOLVersionInfoMapper bolversionInfoMapper,
			IDALVersionInfoMapper dalversionInfoMapper)
			: base()

		{
			this.versionInfoRepository = versionInfoRepository;
			this.versionInfoModelValidator = versionInfoModelValidator;
			this.bolVersionInfoMapper = bolversionInfoMapper;
			this.dalVersionInfoMapper = dalversionInfoMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVersionInfoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.versionInfoRepository.All(skip, take, orderClause);

			return this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVersionInfoResponseModel> Get(long version)
		{
			var record = await versionInfoRepository.Get(version);

			return this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiVersionInfoResponseModel>> Create(
			ApiVersionInfoRequestModel model)
		{
			CreateResponse<ApiVersionInfoResponseModel> response = new CreateResponse<ApiVersionInfoResponseModel>(await this.versionInfoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolVersionInfoMapper.MapModelToBO(default (long), model);
				var record = await this.versionInfoRepository.Create(this.dalVersionInfoMapper.MapBOToEF(bo));

				response.SetRecord(this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			long version,
			ApiVersionInfoRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.versionInfoModelValidator.ValidateUpdateAsync(version, model));

			if (response.Success)
			{
				var bo = this.bolVersionInfoMapper.MapModelToBO(version, model);
				await this.versionInfoRepository.Update(this.dalVersionInfoMapper.MapBOToEF(bo));
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

		public async Task<ApiVersionInfoResponseModel> GetVersion(long version)
		{
			VersionInfo record = await this.versionInfoRepository.GetVersion(version);

			return this.bolVersionInfoMapper.MapBOToModel(this.dalVersionInfoMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>525620dcb39169b638874d11e9d51b94</Hash>
</Codenesium>*/