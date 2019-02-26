using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractOfficerCapabilitiesService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IOfficerCapabilitiesRepository OfficerCapabilitiesRepository { get; private set; }

		protected IApiOfficerCapabilitiesServerRequestModelValidator OfficerCapabilitiesModelValidator { get; private set; }

		protected IDALOfficerCapabilitiesMapper DalOfficerCapabilitiesMapper { get; private set; }

		private ILogger logger;

		public AbstractOfficerCapabilitiesService(
			ILogger logger,
			MediatR.IMediator mediator,
			IOfficerCapabilitiesRepository officerCapabilitiesRepository,
			IApiOfficerCapabilitiesServerRequestModelValidator officerCapabilitiesModelValidator,
			IDALOfficerCapabilitiesMapper dalOfficerCapabilitiesMapper)
			: base()
		{
			this.OfficerCapabilitiesRepository = officerCapabilitiesRepository;
			this.OfficerCapabilitiesModelValidator = officerCapabilitiesModelValidator;
			this.DalOfficerCapabilitiesMapper = dalOfficerCapabilitiesMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiOfficerCapabilitiesServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<OfficerCapabilities> records = await this.OfficerCapabilitiesRepository.All(limit, offset, query);

			return this.DalOfficerCapabilitiesMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiOfficerCapabilitiesServerResponseModel> Get(int capabilityId)
		{
			OfficerCapabilities record = await this.OfficerCapabilitiesRepository.Get(capabilityId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalOfficerCapabilitiesMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiOfficerCapabilitiesServerResponseModel>> Create(
			ApiOfficerCapabilitiesServerRequestModel model)
		{
			CreateResponse<ApiOfficerCapabilitiesServerResponseModel> response = ValidationResponseFactory<ApiOfficerCapabilitiesServerResponseModel>.CreateResponse(await this.OfficerCapabilitiesModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				OfficerCapabilities record = this.DalOfficerCapabilitiesMapper.MapModelToEntity(default(int), model);
				record = await this.OfficerCapabilitiesRepository.Create(record);

				response.SetRecord(this.DalOfficerCapabilitiesMapper.MapEntityToModel(record));
				await this.mediator.Publish(new OfficerCapabilitiesCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiOfficerCapabilitiesServerResponseModel>> Update(
			int capabilityId,
			ApiOfficerCapabilitiesServerRequestModel model)
		{
			var validationResult = await this.OfficerCapabilitiesModelValidator.ValidateUpdateAsync(capabilityId, model);

			if (validationResult.IsValid)
			{
				OfficerCapabilities record = this.DalOfficerCapabilitiesMapper.MapModelToEntity(capabilityId, model);
				await this.OfficerCapabilitiesRepository.Update(record);

				record = await this.OfficerCapabilitiesRepository.Get(capabilityId);

				ApiOfficerCapabilitiesServerResponseModel apiModel = this.DalOfficerCapabilitiesMapper.MapEntityToModel(record);
				await this.mediator.Publish(new OfficerCapabilitiesUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiOfficerCapabilitiesServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiOfficerCapabilitiesServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int capabilityId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.OfficerCapabilitiesModelValidator.ValidateDeleteAsync(capabilityId));

			if (response.Success)
			{
				await this.OfficerCapabilitiesRepository.Delete(capabilityId);

				await this.mediator.Publish(new OfficerCapabilitiesDeletedNotification(capabilityId));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a5a17b0774056c4835864635790201bb</Hash>
</Codenesium>*/