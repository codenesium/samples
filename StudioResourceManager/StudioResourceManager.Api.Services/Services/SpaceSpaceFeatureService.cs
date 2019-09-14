using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class SpaceSpaceFeatureService : AbstractService, ISpaceSpaceFeatureService
	{
		private MediatR.IMediator mediator;

		protected ISpaceSpaceFeatureRepository SpaceSpaceFeatureRepository { get; private set; }

		protected IApiSpaceSpaceFeatureServerRequestModelValidator SpaceSpaceFeatureModelValidator { get; private set; }

		protected IDALSpaceSpaceFeatureMapper DalSpaceSpaceFeatureMapper { get; private set; }

		private ILogger logger;

		public SpaceSpaceFeatureService(
			ILogger<ISpaceSpaceFeatureService> logger,
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

		public virtual async Task<ApiSpaceSpaceFeatureServerResponseModel> Get(int id)
		{
			SpaceSpaceFeature record = await this.SpaceSpaceFeatureRepository.Get(id);

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
			int id,
			ApiSpaceSpaceFeatureServerRequestModel model)
		{
			var validationResult = await this.SpaceSpaceFeatureModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				SpaceSpaceFeature record = this.DalSpaceSpaceFeatureMapper.MapModelToEntity(id, model);
				await this.SpaceSpaceFeatureRepository.Update(record);

				record = await this.SpaceSpaceFeatureRepository.Get(id);

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
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SpaceSpaceFeatureModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SpaceSpaceFeatureRepository.Delete(id);

				await this.mediator.Publish(new SpaceSpaceFeatureDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiSpaceSpaceFeatureServerResponseModel>> BySpaceFeatureId(int spaceFeatureId, int limit = 0, int offset = int.MaxValue)
		{
			List<SpaceSpaceFeature> records = await this.SpaceSpaceFeatureRepository.BySpaceFeatureId(spaceFeatureId, limit, offset);

			return this.DalSpaceSpaceFeatureMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiSpaceSpaceFeatureServerResponseModel>> BySpaceId(int spaceId, int limit = 0, int offset = int.MaxValue)
		{
			List<SpaceSpaceFeature> records = await this.SpaceSpaceFeatureRepository.BySpaceId(spaceId, limit, offset);

			return this.DalSpaceSpaceFeatureMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>82e2a3c433688c6e42b60becede5330c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/