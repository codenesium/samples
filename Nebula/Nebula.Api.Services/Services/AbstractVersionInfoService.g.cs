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
		private IBOLVersionInfoMapper BOLVersionInfoMapper;
		private IDALVersionInfoMapper DALVersionInfoMapper;
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
			this.BOLVersionInfoMapper = bolversionInfoMapper;
			this.DALVersionInfoMapper = dalversionInfoMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVersionInfoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.versionInfoRepository.All(skip, take, orderClause);

			return this.BOLVersionInfoMapper.MapBOToModel(this.DALVersionInfoMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVersionInfoResponseModel> Get(long version)
		{
			var record = await versionInfoRepository.Get(version);

			return this.BOLVersionInfoMapper.MapBOToModel(this.DALVersionInfoMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiVersionInfoResponseModel>> Create(
			ApiVersionInfoRequestModel model)
		{
			CreateResponse<ApiVersionInfoResponseModel> response = new CreateResponse<ApiVersionInfoResponseModel>(await this.versionInfoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLVersionInfoMapper.MapModelToBO(default (long), model);
				var record = await this.versionInfoRepository.Create(this.DALVersionInfoMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLVersionInfoMapper.MapBOToModel(this.DALVersionInfoMapper.MapEFToBO(record)));
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
				var bo = this.BOLVersionInfoMapper.MapModelToBO(version, model);
				await this.versionInfoRepository.Update(this.DALVersionInfoMapper.MapBOToEF(bo));
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

			return this.BOLVersionInfoMapper.MapBOToModel(this.DALVersionInfoMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>0794a1cc58582cdbba581ecac557e44d</Hash>
</Codenesium>*/