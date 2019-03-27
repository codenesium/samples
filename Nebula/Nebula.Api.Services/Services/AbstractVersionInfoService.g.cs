using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractVersionInfoService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVersionInfoRepository VersionInfoRepository { get; private set; }

		protected IApiVersionInfoServerRequestModelValidator VersionInfoModelValidator { get; private set; }

		protected IDALVersionInfoMapper DalVersionInfoMapper { get; private set; }

		private ILogger logger;

		public AbstractVersionInfoService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVersionInfoRepository versionInfoRepository,
			IApiVersionInfoServerRequestModelValidator versionInfoModelValidator,
			IDALVersionInfoMapper dalVersionInfoMapper)
			: base()
		{
			this.VersionInfoRepository = versionInfoRepository;
			this.VersionInfoModelValidator = versionInfoModelValidator;
			this.DalVersionInfoMapper = dalVersionInfoMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVersionInfoServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<VersionInfo> records = await this.VersionInfoRepository.All(limit, offset, query);

			return this.DalVersionInfoMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVersionInfoServerResponseModel> Get(long version)
		{
			VersionInfo record = await this.VersionInfoRepository.Get(version);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVersionInfoMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVersionInfoServerResponseModel>> Create(
			ApiVersionInfoServerRequestModel model)
		{
			CreateResponse<ApiVersionInfoServerResponseModel> response = ValidationResponseFactory<ApiVersionInfoServerResponseModel>.CreateResponse(await this.VersionInfoModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				VersionInfo record = this.DalVersionInfoMapper.MapModelToEntity(default(long), model);
				record = await this.VersionInfoRepository.Create(record);

				response.SetRecord(this.DalVersionInfoMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VersionInfoCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVersionInfoServerResponseModel>> Update(
			long version,
			ApiVersionInfoServerRequestModel model)
		{
			var validationResult = await this.VersionInfoModelValidator.ValidateUpdateAsync(version, model);

			if (validationResult.IsValid)
			{
				VersionInfo record = this.DalVersionInfoMapper.MapModelToEntity(version, model);
				await this.VersionInfoRepository.Update(record);

				record = await this.VersionInfoRepository.Get(version);

				ApiVersionInfoServerResponseModel apiModel = this.DalVersionInfoMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VersionInfoUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVersionInfoServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVersionInfoServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			long version)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VersionInfoModelValidator.ValidateDeleteAsync(version));

			if (response.Success)
			{
				await this.VersionInfoRepository.Delete(version);

				await this.mediator.Publish(new VersionInfoDeletedNotification(version));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>802fb54650eaf0341d17ae85b483f9d3</Hash>
</Codenesium>*/