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
	public abstract class AbstractBOVersionInfo: AbstractBOManager
	{
		private IVersionInfoRepository versionInfoRepository;
		private IApiVersionInfoRequestModelValidator versionInfoModelValidator;
		private IBOLVersionInfoMapper versionInfoMapper;
		private ILogger logger;

		public AbstractBOVersionInfo(
			ILogger logger,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoRequestModelValidator versionInfoModelValidator,
			IBOLVersionInfoMapper versionInfoMapper)
			: base()

		{
			this.versionInfoRepository = versionInfoRepository;
			this.versionInfoModelValidator = versionInfoModelValidator;
			this.versionInfoMapper = versionInfoMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVersionInfoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.versionInfoRepository.All(skip, take, orderClause);

			return this.versionInfoMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiVersionInfoResponseModel> Get(long version)
		{
			var record = await versionInfoRepository.Get(version);

			return this.versionInfoMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiVersionInfoResponseModel>> Create(
			ApiVersionInfoRequestModel model)
		{
			CreateResponse<ApiVersionInfoResponseModel> response = new CreateResponse<ApiVersionInfoResponseModel>(await this.versionInfoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.versionInfoMapper.MapModelToDTO(default (long), model);
				var record = await this.versionInfoRepository.Create(dto);

				response.SetRecord(this.versionInfoMapper.MapDTOToModel(record));
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
				var dto = this.versionInfoMapper.MapModelToDTO(version, model);
				await this.versionInfoRepository.Update(version, dto);
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
			DTOVersionInfo record = await this.versionInfoRepository.GetVersion(version);

			return this.versionInfoMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>c2fa218073ffb861cf22329a741190ad</Hash>
</Codenesium>*/