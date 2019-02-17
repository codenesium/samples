using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractSpaceService : AbstractService
	{
		private IMediator mediator;

		protected ISpaceRepository SpaceRepository { get; private set; }

		protected IApiSpaceServerRequestModelValidator SpaceModelValidator { get; private set; }

		protected IDALSpaceMapper DalSpaceMapper { get; private set; }

		private ILogger logger;

		public AbstractSpaceService(
			ILogger logger,
			IMediator mediator,
			ISpaceRepository spaceRepository,
			IApiSpaceServerRequestModelValidator spaceModelValidator,
			IDALSpaceMapper dalSpaceMapper)
			: base()
		{
			this.SpaceRepository = spaceRepository;
			this.SpaceModelValidator = spaceModelValidator;
			this.DalSpaceMapper = dalSpaceMapper;
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
	}
}

/*<Codenesium>
    <Hash>5a64b473c3ac2698484761bf22bc48c0</Hash>
</Codenesium>*/