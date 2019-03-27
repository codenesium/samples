using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractSpaceSpaceFeatureService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ISpaceSpaceFeatureRepository SpaceSpaceFeatureRepository { get; private set; }

		protected IApiSpaceSpaceFeatureServerRequestModelValidator SpaceSpaceFeatureModelValidator { get; private set; }

		protected IDALSpaceSpaceFeatureMapper DalSpaceSpaceFeatureMapper { get; private set; }

		private ILogger logger;

		public AbstractSpaceSpaceFeatureService(
			ILogger logger,
			MediatR.IMediator mediator,
			ISpaceSpaceFeatureRepository spaceSpaceFeatureRepository,
			IApiSpaceSpaceFeatureServerRequestModelValidator spaceSpaceFeatureModelValidator,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper)
			: base()
		{
			this.SpaceSpaceFeatureRepository = spaceSpaceFeatureRepository;
			this.SpaceSpaceFeatureModelValidator = spaceSpaceFeatureModelValidator;
			this.DalSpaceSpaceFeatureMapper = dalSpaceSpaceFeatureMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSpaceSpaceFeatureServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<SpaceSpaceFeature> records = await this.SpaceSpaceFeatureRepository.All(limit, offset, query);

			return this.DalSpaceSpaceFeatureMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSpaceSpaceFeatureServerResponseModel> Get(int spaceId)
		{
			SpaceSpaceFeature record = await this.SpaceSpaceFeatureRepository.Get(spaceId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSpaceSpaceFeatureMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSpaceSpaceFeatureServerResponseModel>> Create(
			ApiSpaceSpaceFeatureServerRequestModel model)
		{
			CreateResponse<ApiSpaceSpaceFeatureServerResponseModel> response = ValidationResponseFactory<ApiSpaceSpaceFeatureServerResponseModel>.CreateResponse(await this.SpaceSpaceFeatureModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				SpaceSpaceFeature record = this.DalSpaceSpaceFeatureMapper.MapModelToEntity(default(int), model);
				record = await this.SpaceSpaceFeatureRepository.Create(record);

				response.SetRecord(this.DalSpaceSpaceFeatureMapper.MapEntityToModel(record));
				await this.mediator.Publish(new SpaceSpaceFeatureCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpaceSpaceFeatureServerResponseModel>> Update(
			int spaceId,
			ApiSpaceSpaceFeatureServerRequestModel model)
		{
			var validationResult = await this.SpaceSpaceFeatureModelValidator.ValidateUpdateAsync(spaceId, model);

			if (validationResult.IsValid)
			{
				SpaceSpaceFeature record = this.DalSpaceSpaceFeatureMapper.MapModelToEntity(spaceId, model);
				await this.SpaceSpaceFeatureRepository.Update(record);

				record = await this.SpaceSpaceFeatureRepository.Get(spaceId);

				ApiSpaceSpaceFeatureServerResponseModel apiModel = this.DalSpaceSpaceFeatureMapper.MapEntityToModel(record);
				await this.mediator.Publish(new SpaceSpaceFeatureUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSpaceSpaceFeatureServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSpaceSpaceFeatureServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int spaceId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SpaceSpaceFeatureModelValidator.ValidateDeleteAsync(spaceId));

			if (response.Success)
			{
				await this.SpaceSpaceFeatureRepository.Delete(spaceId);

				await this.mediator.Publish(new SpaceSpaceFeatureDeletedNotification(spaceId));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d26cfd772859b12e820e5495d9aebfe8</Hash>
</Codenesium>*/