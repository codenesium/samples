using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractAWBuildVersionService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IAWBuildVersionRepository AWBuildVersionRepository { get; private set; }

		protected IApiAWBuildVersionServerRequestModelValidator AWBuildVersionModelValidator { get; private set; }

		protected IDALAWBuildVersionMapper DalAWBuildVersionMapper { get; private set; }

		private ILogger logger;

		public AbstractAWBuildVersionService(
			ILogger logger,
			MediatR.IMediator mediator,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IApiAWBuildVersionServerRequestModelValidator aWBuildVersionModelValidator,
			IDALAWBuildVersionMapper dalAWBuildVersionMapper)
			: base()
		{
			this.AWBuildVersionRepository = aWBuildVersionRepository;
			this.AWBuildVersionModelValidator = aWBuildVersionModelValidator;
			this.DalAWBuildVersionMapper = dalAWBuildVersionMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiAWBuildVersionServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<AWBuildVersion> records = await this.AWBuildVersionRepository.All(limit, offset, query);

			return this.DalAWBuildVersionMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiAWBuildVersionServerResponseModel> Get(int systemInformationID)
		{
			AWBuildVersion record = await this.AWBuildVersionRepository.Get(systemInformationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalAWBuildVersionMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiAWBuildVersionServerResponseModel>> Create(
			ApiAWBuildVersionServerRequestModel model)
		{
			CreateResponse<ApiAWBuildVersionServerResponseModel> response = ValidationResponseFactory<ApiAWBuildVersionServerResponseModel>.CreateResponse(await this.AWBuildVersionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				AWBuildVersion record = this.DalAWBuildVersionMapper.MapModelToEntity(default(int), model);
				record = await this.AWBuildVersionRepository.Create(record);

				response.SetRecord(this.DalAWBuildVersionMapper.MapEntityToModel(record));
				await this.mediator.Publish(new AWBuildVersionCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAWBuildVersionServerResponseModel>> Update(
			int systemInformationID,
			ApiAWBuildVersionServerRequestModel model)
		{
			var validationResult = await this.AWBuildVersionModelValidator.ValidateUpdateAsync(systemInformationID, model);

			if (validationResult.IsValid)
			{
				AWBuildVersion record = this.DalAWBuildVersionMapper.MapModelToEntity(systemInformationID, model);
				await this.AWBuildVersionRepository.Update(record);

				record = await this.AWBuildVersionRepository.Get(systemInformationID);

				ApiAWBuildVersionServerResponseModel apiModel = this.DalAWBuildVersionMapper.MapEntityToModel(record);
				await this.mediator.Publish(new AWBuildVersionUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiAWBuildVersionServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiAWBuildVersionServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int systemInformationID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AWBuildVersionModelValidator.ValidateDeleteAsync(systemInformationID));

			if (response.Success)
			{
				await this.AWBuildVersionRepository.Delete(systemInformationID);

				await this.mediator.Publish(new AWBuildVersionDeletedNotification(systemInformationID));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c9bcdbd6ae86dcbd46ef80a0efd94ccd</Hash>
</Codenesium>*/