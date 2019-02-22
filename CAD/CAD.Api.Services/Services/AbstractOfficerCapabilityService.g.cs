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

		protected IDALOfficerRefCapabilityMapper DalOfficerRefCapabilityMapper { get; private set; }

		private ILogger logger;

		public AbstractOfficerCapabilityService(
			ILogger logger,
			MediatR.IMediator mediator,
			IOfficerCapabilityRepository officerCapabilityRepository,
			IApiOfficerCapabilityServerRequestModelValidator officerCapabilityModelValidator,
			IDALOfficerCapabilityMapper dalOfficerCapabilityMapper,
			IDALOfficerRefCapabilityMapper dalOfficerRefCapabilityMapper)
			: base()
		{
			this.OfficerCapabilityRepository = officerCapabilityRepository;
			this.OfficerCapabilityModelValidator = officerCapabilityModelValidator;
			this.DalOfficerCapabilityMapper = dalOfficerCapabilityMapper;
			this.DalOfficerRefCapabilityMapper = dalOfficerRefCapabilityMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiOfficerCapabilityServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<OfficerCapability> records = await this.OfficerCapabilityRepository.All(limit, offset, query);

			return this.DalOfficerCapabilityMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiOfficerCapabilityServerResponseModel> Get(int id)
		{
			OfficerCapability record = await this.OfficerCapabilityRepository.Get(id);

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
			int id,
			ApiOfficerCapabilityServerRequestModel model)
		{
			var validationResult = await this.OfficerCapabilityModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				OfficerCapability record = this.DalOfficerCapabilityMapper.MapModelToEntity(id, model);
				await this.OfficerCapabilityRepository.Update(record);

				record = await this.OfficerCapabilityRepository.Get(id);

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
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.OfficerCapabilityModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.OfficerCapabilityRepository.Delete(id);

				await this.mediator.Publish(new OfficerCapabilityDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiOfficerRefCapabilityServerResponseModel>> OfficerRefCapabilitiesByCapabilityId(int capabilityId, int limit = int.MaxValue, int offset = 0)
		{
			List<OfficerRefCapability> records = await this.OfficerCapabilityRepository.OfficerRefCapabilitiesByCapabilityId(capabilityId, limit, offset);

			return this.DalOfficerRefCapabilityMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>edcf5652d6bf81e88a475b71922ee114</Hash>
</Codenesium>*/