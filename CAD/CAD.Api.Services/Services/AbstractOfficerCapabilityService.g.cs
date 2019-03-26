using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractOfficerCapabilityService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IOfficerCapabilityRepository OfficerCapabilityRepository { get; private set; }

		protected IApiOfficerCapabilityServerRequestModelValidator OfficerCapabilityModelValidator { get; private set; }

		protected IDALOfficerCapabilityMapper DalOfficerCapabilityMapper { get; private set; }

		private ILogger logger;

		public AbstractOfficerCapabilityService(
			ILogger logger,
			MediatR.IMediator mediator,
			IOfficerCapabilityRepository officerCapabilityRepository,
			IApiOfficerCapabilityServerRequestModelValidator officerCapabilityModelValidator,
			IDALOfficerCapabilityMapper dalOfficerCapabilityMapper)
			: base()
		{
			this.OfficerCapabilityRepository = officerCapabilityRepository;
			this.OfficerCapabilityModelValidator = officerCapabilityModelValidator;
			this.DalOfficerCapabilityMapper = dalOfficerCapabilityMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiOfficerCapabilityServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<OfficerCapability> records = await this.OfficerCapabilityRepository.All(limit, offset, query);

			return this.DalOfficerCapabilityMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiOfficerCapabilityServerResponseModel> Get(int capabilityId)
		{
			OfficerCapability record = await this.OfficerCapabilityRepository.Get(capabilityId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalOfficerCapabilityMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiOfficerCapabilityServerResponseModel>> Create(
			ApiOfficerCapabilityServerRequestModel model)
		{
			CreateResponse<ApiOfficerCapabilityServerResponseModel> response = ValidationResponseFactory<ApiOfficerCapabilityServerResponseModel>.CreateResponse(await this.OfficerCapabilityModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				OfficerCapability record = this.DalOfficerCapabilityMapper.MapModelToEntity(default(int), model);
				record = await this.OfficerCapabilityRepository.Create(record);

				response.SetRecord(this.DalOfficerCapabilityMapper.MapEntityToModel(record));
				await this.mediator.Publish(new OfficerCapabilityCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiOfficerCapabilityServerResponseModel>> Update(
			int capabilityId,
			ApiOfficerCapabilityServerRequestModel model)
		{
			var validationResult = await this.OfficerCapabilityModelValidator.ValidateUpdateAsync(capabilityId, model);

			if (validationResult.IsValid)
			{
				OfficerCapability record = this.DalOfficerCapabilityMapper.MapModelToEntity(capabilityId, model);
				await this.OfficerCapabilityRepository.Update(record);

				record = await this.OfficerCapabilityRepository.Get(capabilityId);

				ApiOfficerCapabilityServerResponseModel apiModel = this.DalOfficerCapabilityMapper.MapEntityToModel(record);
				await this.mediator.Publish(new OfficerCapabilityUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiOfficerCapabilityServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiOfficerCapabilityServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int capabilityId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.OfficerCapabilityModelValidator.ValidateDeleteAsync(capabilityId));

			if (response.Success)
			{
				await this.OfficerCapabilityRepository.Delete(capabilityId);

				await this.mediator.Publish(new OfficerCapabilityDeletedNotification(capabilityId));
			}

			return response;
		}

		public async virtual Task<List<ApiOfficerCapabilityServerResponseModel>> ByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			List<OfficerCapability> records = await this.OfficerCapabilityRepository.ByOfficerId(officerId, limit, offset);

			return this.DalOfficerCapabilityMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>4663c0950ca59e8b118ca13a899a454b</Hash>
</Codenesium>*/