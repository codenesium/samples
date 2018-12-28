using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractSpaceFeatureService : AbstractService
	{
		private IMediator mediator;

		protected ISpaceFeatureRepository SpaceFeatureRepository { get; private set; }

		protected IApiSpaceFeatureServerRequestModelValidator SpaceFeatureModelValidator { get; private set; }

		protected IBOLSpaceFeatureMapper BolSpaceFeatureMapper { get; private set; }

		protected IDALSpaceFeatureMapper DalSpaceFeatureMapper { get; private set; }

		private ILogger logger;

		public AbstractSpaceFeatureService(
			ILogger logger,
			IMediator mediator,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureServerRequestModelValidator spaceFeatureModelValidator,
			IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper)
			: base()
		{
			this.SpaceFeatureRepository = spaceFeatureRepository;
			this.SpaceFeatureModelValidator = spaceFeatureModelValidator;
			this.BolSpaceFeatureMapper = bolSpaceFeatureMapper;
			this.DalSpaceFeatureMapper = dalSpaceFeatureMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSpaceFeatureServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpaceFeatureRepository.All(limit, offset);

			return this.BolSpaceFeatureMapper.MapBOToModel(this.DalSpaceFeatureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpaceFeatureServerResponseModel> Get(int id)
		{
			var record = await this.SpaceFeatureRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSpaceFeatureMapper.MapBOToModel(this.DalSpaceFeatureMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSpaceFeatureServerResponseModel>> Create(
			ApiSpaceFeatureServerRequestModel model)
		{
			CreateResponse<ApiSpaceFeatureServerResponseModel> response = ValidationResponseFactory<ApiSpaceFeatureServerResponseModel>.CreateResponse(await this.SpaceFeatureModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSpaceFeatureMapper.MapModelToBO(default(int), model);
				var record = await this.SpaceFeatureRepository.Create(this.DalSpaceFeatureMapper.MapBOToEF(bo));

				var businessObject = this.DalSpaceFeatureMapper.MapEFToBO(record);
				response.SetRecord(this.BolSpaceFeatureMapper.MapBOToModel(businessObject));
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
				var bo = this.BolSpaceFeatureMapper.MapModelToBO(id, model);
				await this.SpaceFeatureRepository.Update(this.DalSpaceFeatureMapper.MapBOToEF(bo));

				var record = await this.SpaceFeatureRepository.Get(id);

				var businessObject = this.DalSpaceFeatureMapper.MapEFToBO(record);
				var apiModel = this.BolSpaceFeatureMapper.MapBOToModel(businessObject);
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

		public async virtual Task<List<ApiSpaceFeatureServerResponseModel>> BySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0)
		{
			List<SpaceFeature> records = await this.SpaceFeatureRepository.BySpaceId(spaceId, limit, offset);

			return this.BolSpaceFeatureMapper.MapBOToModel(this.DalSpaceFeatureMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b146ddd2da85eb717fa8c0e620de8120</Hash>
</Codenesium>*/