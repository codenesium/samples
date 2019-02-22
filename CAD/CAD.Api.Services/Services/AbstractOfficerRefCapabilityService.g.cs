using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractOfficerRefCapabilityService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IOfficerRefCapabilityRepository OfficerRefCapabilityRepository { get; private set; }

		protected IApiOfficerRefCapabilityServerRequestModelValidator OfficerRefCapabilityModelValidator { get; private set; }

		protected IDALOfficerRefCapabilityMapper DalOfficerRefCapabilityMapper { get; private set; }

		private ILogger logger;

		public AbstractOfficerRefCapabilityService(
			ILogger logger,
			MediatR.IMediator mediator,
			IOfficerRefCapabilityRepository officerRefCapabilityRepository,
			IApiOfficerRefCapabilityServerRequestModelValidator officerRefCapabilityModelValidator,
			IDALOfficerRefCapabilityMapper dalOfficerRefCapabilityMapper)
			: base()
		{
			this.OfficerRefCapabilityRepository = officerRefCapabilityRepository;
			this.OfficerRefCapabilityModelValidator = officerRefCapabilityModelValidator;
			this.DalOfficerRefCapabilityMapper = dalOfficerRefCapabilityMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiOfficerRefCapabilityServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<OfficerRefCapability> records = await this.OfficerRefCapabilityRepository.All(limit, offset, query);

			return this.DalOfficerRefCapabilityMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiOfficerRefCapabilityServerResponseModel> Get(int id)
		{
			OfficerRefCapability record = await this.OfficerRefCapabilityRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalOfficerRefCapabilityMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiOfficerRefCapabilityServerResponseModel>> Create(
			ApiOfficerRefCapabilityServerRequestModel model)
		{
			CreateResponse<ApiOfficerRefCapabilityServerResponseModel> response = ValidationResponseFactory<ApiOfficerRefCapabilityServerResponseModel>.CreateResponse(await this.OfficerRefCapabilityModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				OfficerRefCapability record = this.DalOfficerRefCapabilityMapper.MapModelToEntity(default(int), model);
				record = await this.OfficerRefCapabilityRepository.Create(record);

				response.SetRecord(this.DalOfficerRefCapabilityMapper.MapEntityToModel(record));
				await this.mediator.Publish(new OfficerRefCapabilityCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>> Update(
			int id,
			ApiOfficerRefCapabilityServerRequestModel model)
		{
			var validationResult = await this.OfficerRefCapabilityModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				OfficerRefCapability record = this.DalOfficerRefCapabilityMapper.MapModelToEntity(id, model);
				await this.OfficerRefCapabilityRepository.Update(record);

				record = await this.OfficerRefCapabilityRepository.Get(id);

				ApiOfficerRefCapabilityServerResponseModel apiModel = this.DalOfficerRefCapabilityMapper.MapEntityToModel(record);
				await this.mediator.Publish(new OfficerRefCapabilityUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiOfficerRefCapabilityServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiOfficerRefCapabilityServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.OfficerRefCapabilityModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.OfficerRefCapabilityRepository.Delete(id);

				await this.mediator.Publish(new OfficerRefCapabilityDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5c51463edda81c12de723ac5fb56e1a2</Hash>
</Codenesium>*/