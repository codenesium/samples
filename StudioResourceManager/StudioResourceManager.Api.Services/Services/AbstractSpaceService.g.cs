using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractSpaceService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ISpaceRepository SpaceRepository { get; private set; }

		protected IApiSpaceServerRequestModelValidator SpaceModelValidator { get; private set; }

		protected IDALSpaceMapper DalSpaceMapper { get; private set; }

		protected IDALSpaceSpaceFeatureMapper DalSpaceSpaceFeatureMapper { get; private set; }

		private ILogger logger;

		public AbstractSpaceService(
			ILogger logger,
			MediatR.IMediator mediator,
			ISpaceRepository spaceRepository,
			IApiSpaceServerRequestModelValidator spaceModelValidator,
			IDALSpaceMapper dalSpaceMapper,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper)
			: base()
		{
			this.SpaceRepository = spaceRepository;
			this.SpaceModelValidator = spaceModelValidator;
			this.DalSpaceMapper = dalSpaceMapper;
			this.DalSpaceSpaceFeatureMapper = dalSpaceSpaceFeatureMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSpaceServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Space> records = await this.SpaceRepository.All(limit, offset, query);

			return this.DalSpaceMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSpaceServerResponseModel> Get(int id)
		{
			Space record = await this.SpaceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSpaceMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSpaceServerResponseModel>> Create(
			ApiSpaceServerRequestModel model)
		{
			CreateResponse<ApiSpaceServerResponseModel> response = ValidationResponseFactory<ApiSpaceServerResponseModel>.CreateResponse(await this.SpaceModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Space record = this.DalSpaceMapper.MapModelToEntity(default(int), model);
				record = await this.SpaceRepository.Create(record);

				response.SetRecord(this.DalSpaceMapper.MapEntityToModel(record));
				await this.mediator.Publish(new SpaceCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpaceServerResponseModel>> Update(
			int id,
			ApiSpaceServerRequestModel model)
		{
			var validationResult = await this.SpaceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Space record = this.DalSpaceMapper.MapModelToEntity(id, model);
				await this.SpaceRepository.Update(record);

				record = await this.SpaceRepository.Get(id);

				ApiSpaceServerResponseModel apiModel = this.DalSpaceMapper.MapEntityToModel(record);
				await this.mediator.Publish(new SpaceUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSpaceServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSpaceServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SpaceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SpaceRepository.Delete(id);

				await this.mediator.Publish(new SpaceDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiSpaceSpaceFeatureServerResponseModel>> SpaceSpaceFeaturesBySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0)
		{
			List<SpaceSpaceFeature> records = await this.SpaceRepository.SpaceSpaceFeaturesBySpaceId(spaceId, limit, offset);

			return this.DalSpaceSpaceFeatureMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>631f2f0d97c4ea95e1ab2d71396ea09b</Hash>
</Codenesium>*/