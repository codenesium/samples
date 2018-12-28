using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractStudioService : AbstractService
	{
		private IMediator mediator;

		protected IStudioRepository StudioRepository { get; private set; }

		protected IApiStudioServerRequestModelValidator StudioModelValidator { get; private set; }

		protected IBOLStudioMapper BolStudioMapper { get; private set; }

		protected IDALStudioMapper DalStudioMapper { get; private set; }

		private ILogger logger;

		public AbstractStudioService(
			ILogger logger,
			IMediator mediator,
			IStudioRepository studioRepository,
			IApiStudioServerRequestModelValidator studioModelValidator,
			IBOLStudioMapper bolStudioMapper,
			IDALStudioMapper dalStudioMapper)
			: base()
		{
			this.StudioRepository = studioRepository;
			this.StudioModelValidator = studioModelValidator;
			this.BolStudioMapper = bolStudioMapper;
			this.DalStudioMapper = dalStudioMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiStudioServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.StudioRepository.All(limit, offset);

			return this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStudioServerResponseModel> Get(int id)
		{
			var record = await this.StudioRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiStudioServerResponseModel>> Create(
			ApiStudioServerRequestModel model)
		{
			CreateResponse<ApiStudioServerResponseModel> response = ValidationResponseFactory<ApiStudioServerResponseModel>.CreateResponse(await this.StudioModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolStudioMapper.MapModelToBO(default(int), model);
				var record = await this.StudioRepository.Create(this.DalStudioMapper.MapBOToEF(bo));

				var recordMappedToBusinessObject = this.DalStudioMapper.MapEFToBO(record);
				response.SetRecord(this.BolStudioMapper.MapBOToModel(recordMappedToBusinessObject));
				await this.mediator.Publish(new StudioCreatedNotification(recordMappedToBusinessObject));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStudioServerResponseModel>> Update(
			int id,
			ApiStudioServerRequestModel model)
		{
			var validationResult = await this.StudioModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolStudioMapper.MapModelToBO(id, model);
				await this.StudioRepository.Update(this.DalStudioMapper.MapBOToEF(bo));

				var record = await this.StudioRepository.Get(id);

				var recordMappedToBusinessObject = this.DalStudioMapper.MapEFToBO(record);
				await this.mediator.Publish(new StudioUpdatedNotification(recordMappedToBusinessObject));

				return ValidationResponseFactory<ApiStudioServerResponseModel>.UpdateResponse(this.BolStudioMapper.MapBOToModel(recordMappedToBusinessObject));
			}
			else
			{
				return ValidationResponseFactory<ApiStudioServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.StudioModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.StudioRepository.Delete(id);

				await this.mediator.Publish(new StudioDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0b19e6d6ee1f8ea27c9d0b811fd58c07</Hash>
</Codenesium>*/