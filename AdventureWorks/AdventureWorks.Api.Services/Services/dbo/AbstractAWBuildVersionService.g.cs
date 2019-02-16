using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractAWBuildVersionService : AbstractService
	{
		private IMediator mediator;

		protected IAWBuildVersionRepository AWBuildVersionRepository { get; private set; }

		protected IApiAWBuildVersionServerRequestModelValidator AWBuildVersionModelValidator { get; private set; }

		protected IDALAWBuildVersionMapper DalAWBuildVersionMapper { get; private set; }

		private ILogger logger;

		public AbstractAWBuildVersionService(
			ILogger logger,
			IMediator mediator,
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
			var records = await this.AWBuildVersionRepository.All(limit, offset, query);

			return this.DalAWBuildVersionMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiAWBuildVersionServerResponseModel> Get(int systemInformationID)
		{
			var record = await this.AWBuildVersionRepository.Get(systemInformationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalAWBuildVersionMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiAWBuildVersionServerResponseModel>> Create(
			ApiAWBuildVersionServerRequestModel model)
		{
			CreateResponse<ApiAWBuildVersionServerResponseModel> response = ValidationResponseFactory<ApiAWBuildVersionServerResponseModel>.CreateResponse(await this.AWBuildVersionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalAWBuildVersionMapper.MapModelToBO(default(int), model);
				var record = await this.AWBuildVersionRepository.Create(bo);

				response.SetRecord(this.DalAWBuildVersionMapper.MapBOToModel(record));
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
				var bo = this.DalAWBuildVersionMapper.MapModelToBO(systemInformationID, model);
				await this.AWBuildVersionRepository.Update(bo);

				var record = await this.AWBuildVersionRepository.Get(systemInformationID);

				var apiModel = this.DalAWBuildVersionMapper.MapBOToModel(record);
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
    <Hash>675d9d1085984982fd0100bd249f5bc9</Hash>
</Codenesium>*/