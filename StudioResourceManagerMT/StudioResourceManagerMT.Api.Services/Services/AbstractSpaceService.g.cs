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

		protected IBOLSpaceMapper BolSpaceMapper { get; private set; }

		protected IDALSpaceMapper DalSpaceMapper { get; private set; }

		private ILogger logger;

		public AbstractSpaceService(
			ILogger logger,
			IMediator mediator,
			ISpaceRepository spaceRepository,
			IApiSpaceServerRequestModelValidator spaceModelValidator,
			IBOLSpaceMapper bolSpaceMapper,
			IDALSpaceMapper dalSpaceMapper)
			: base()
		{
			this.SpaceRepository = spaceRepository;
			this.SpaceModelValidator = spaceModelValidator;
			this.BolSpaceMapper = bolSpaceMapper;
			this.DalSpaceMapper = dalSpaceMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSpaceServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpaceRepository.All(limit, offset);

			return this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpaceServerResponseModel> Get(int id)
		{
			var record = await this.SpaceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSpaceServerResponseModel>> Create(
			ApiSpaceServerRequestModel model)
		{
			CreateResponse<ApiSpaceServerResponseModel> response = ValidationResponseFactory<ApiSpaceServerResponseModel>.CreateResponse(await this.SpaceModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSpaceMapper.MapModelToBO(default(int), model);
				var record = await this.SpaceRepository.Create(this.DalSpaceMapper.MapBOToEF(bo));

				var recordMappedToBusinessObject = this.DalSpaceMapper.MapEFToBO(record);
				response.SetRecord(this.BolSpaceMapper.MapBOToModel(recordMappedToBusinessObject));
				await this.mediator.Publish(new SpaceCreatedNotification(recordMappedToBusinessObject));
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
				var bo = this.BolSpaceMapper.MapModelToBO(id, model);
				await this.SpaceRepository.Update(this.DalSpaceMapper.MapBOToEF(bo));

				var record = await this.SpaceRepository.Get(id);

				var recordMappedToBusinessObject = this.DalSpaceMapper.MapEFToBO(record);
				await this.mediator.Publish(new SpaceUpdatedNotification(recordMappedToBusinessObject));

				return ValidationResponseFactory<ApiSpaceServerResponseModel>.UpdateResponse(this.BolSpaceMapper.MapBOToModel(recordMappedToBusinessObject));
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
    <Hash>77b69130be4313018081eee4269e0b03</Hash>
</Codenesium>*/