using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractVersionInfoService : AbstractService
	{
		protected IVersionInfoRepository VersionInfoRepository { get; private set; }

		protected IApiVersionInfoRequestModelValidator VersionInfoModelValidator { get; private set; }

		protected IBOLVersionInfoMapper BolVersionInfoMapper { get; private set; }

		protected IDALVersionInfoMapper DalVersionInfoMapper { get; private set; }

		private ILogger logger;

		public AbstractVersionInfoService(
			ILogger logger,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoRequestModelValidator versionInfoModelValidator,
			IBOLVersionInfoMapper bolVersionInfoMapper,
			IDALVersionInfoMapper dalVersionInfoMapper)
			: base()
		{
			this.VersionInfoRepository = versionInfoRepository;
			this.VersionInfoModelValidator = versionInfoModelValidator;
			this.BolVersionInfoMapper = bolVersionInfoMapper;
			this.DalVersionInfoMapper = dalVersionInfoMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVersionInfoResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VersionInfoRepository.All(limit, offset);

			return this.BolVersionInfoMapper.MapBOToModel(this.DalVersionInfoMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVersionInfoResponseModel> Get(long version)
		{
			var record = await this.VersionInfoRepository.Get(version);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVersionInfoMapper.MapBOToModel(this.DalVersionInfoMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVersionInfoResponseModel>> Create(
			ApiVersionInfoRequestModel model)
		{
			CreateResponse<ApiVersionInfoResponseModel> response = new CreateResponse<ApiVersionInfoResponseModel>(await this.VersionInfoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVersionInfoMapper.MapModelToBO(default(long), model);
				var record = await this.VersionInfoRepository.Create(this.DalVersionInfoMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVersionInfoMapper.MapBOToModel(this.DalVersionInfoMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVersionInfoResponseModel>> Update(
			long version,
			ApiVersionInfoRequestModel model)
		{
			var validationResult = await this.VersionInfoModelValidator.ValidateUpdateAsync(version, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVersionInfoMapper.MapModelToBO(version, model);
				await this.VersionInfoRepository.Update(this.DalVersionInfoMapper.MapBOToEF(bo));

				var record = await this.VersionInfoRepository.Get(version);

				return new UpdateResponse<ApiVersionInfoResponseModel>(this.BolVersionInfoMapper.MapBOToModel(this.DalVersionInfoMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVersionInfoResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			long version)
		{
			ActionResponse response = new ActionResponse(await this.VersionInfoModelValidator.ValidateDeleteAsync(version));
			if (response.Success)
			{
				await this.VersionInfoRepository.Delete(version);
			}

			return response;
		}

		public async Task<ApiVersionInfoResponseModel> ByVersion(long version)
		{
			VersionInfo record = await this.VersionInfoRepository.ByVersion(version);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVersionInfoMapper.MapBOToModel(this.DalVersionInfoMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>3fc53d17abc029734ac95cfc649a1b8d</Hash>
</Codenesium>*/