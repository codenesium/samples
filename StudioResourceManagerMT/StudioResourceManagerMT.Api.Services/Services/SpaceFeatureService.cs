using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class SpaceFeatureService : AbstractService, ISpaceFeatureService
	{
		private MediatR.IMediator mediator;

		protected ISpaceFeatureRepository SpaceFeatureRepository { get; private set; }

		protected IApiSpaceFeatureServerRequestModelValidator SpaceFeatureModelValidator { get; private set; }

		protected IDALSpaceFeatureMapper DalSpaceFeatureMapper { get; private set; }

		protected IDALSpaceSpaceFeatureMapper DalSpaceSpaceFeatureMapper { get; private set; }

		private ILogger logger;

		public SpaceFeatureService(
			ILogger<ISpaceFeatureService> logger,
			MediatR.IMediator mediator,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureServerRequestModelValidator spaceFeatureModelValidator,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper)
			: base()
		{
			this.SpaceFeatureRepository = spaceFeatureRepository;
			this.SpaceFeatureModelValidator = spaceFeatureModelValidator;
			this.DalSpaceFeatureMapper = dalSpaceFeatureMapper;
			this.DalSpaceSpaceFeatureMapper = dalSpaceSpaceFeatureMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSpaceFeatureServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<SpaceFeature> records = await this.SpaceFeatureRepository.All(limit, offset, query);

			return this.DalSpaceFeatureMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSpaceFeatureServerResponseModel> Get(int id)
		{
			SpaceFeature record = await this.SpaceFeatureRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSpaceFeatureMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSpaceFeatureServerResponseModel>> Create(
			ApiSpaceFeatureServerRequestModel model)
		{
			CreateResponse<ApiSpaceFeatureServerResponseModel> response = ValidationResponseFactory<ApiSpaceFeatureServerResponseModel>.CreateResponse(await this.SpaceFeatureModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				SpaceFeature record = this.DalSpaceFeatureMapper.MapModelToEntity(default(int), model);
				record = await this.SpaceFeatureRepository.Create(record);

				response.SetRecord(this.DalSpaceFeatureMapper.MapEntityToModel(record));
				await this.mediator.Publish(new SpaceFeatureCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpaceFeatureServerResponseModel>> Update(
			int id,
			ApiSpaceFeatureServerRequestModel model)
		{
			var validationResult = await this.SpaceFeatureModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				SpaceFeature record = this.DalSpaceFeatureMapper.MapModelToEntity(id, model);
				await this.SpaceFeatureRepository.Update(record);

				record = await this.SpaceFeatureRepository.Get(id);

				ApiSpaceFeatureServerResponseModel apiModel = this.DalSpaceFeatureMapper.MapEntityToModel(record);
				await this.mediator.Publish(new SpaceFeatureUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSpaceFeatureServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSpaceFeatureServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SpaceFeatureModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SpaceFeatureRepository.Delete(id);

				await this.mediator.Publish(new SpaceFeatureDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiSpaceSpaceFeatureServerResponseModel>> SpaceSpaceFeaturesBySpaceFeatureId(int spaceFeatureId, int limit = int.MaxValue, int offset = 0)
		{
			List<SpaceSpaceFeature> records = await this.SpaceFeatureRepository.SpaceSpaceFeaturesBySpaceFeatureId(spaceFeatureId, limit, offset);

			return this.DalSpaceSpaceFeatureMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>9a257e9b087197ef8d83ad2a6f0611fe</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/