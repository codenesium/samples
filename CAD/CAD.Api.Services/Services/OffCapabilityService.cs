using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class OffCapabilityService : AbstractService, IOffCapabilityService
	{
		private MediatR.IMediator mediator;

		protected IOffCapabilityRepository OffCapabilityRepository { get; private set; }

		protected IApiOffCapabilityServerRequestModelValidator OffCapabilityModelValidator { get; private set; }

		protected IDALOffCapabilityMapper DalOffCapabilityMapper { get; private set; }

		protected IDALOfficerCapabilitiesMapper DalOfficerCapabilitiesMapper { get; private set; }

		private ILogger logger;

		public OffCapabilityService(
			ILogger<IOffCapabilityService> logger,
			MediatR.IMediator mediator,
			IOffCapabilityRepository offCapabilityRepository,
			IApiOffCapabilityServerRequestModelValidator offCapabilityModelValidator,
			IDALOffCapabilityMapper dalOffCapabilityMapper,
			IDALOfficerCapabilitiesMapper dalOfficerCapabilitiesMapper)
			: base()
		{
			this.OffCapabilityRepository = offCapabilityRepository;
			this.OffCapabilityModelValidator = offCapabilityModelValidator;
			this.DalOffCapabilityMapper = dalOffCapabilityMapper;
			this.DalOfficerCapabilitiesMapper = dalOfficerCapabilitiesMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiOffCapabilityServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<OffCapability> records = await this.OffCapabilityRepository.All(limit, offset, query);

			return this.DalOffCapabilityMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiOffCapabilityServerResponseModel> Get(int id)
		{
			OffCapability record = await this.OffCapabilityRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalOffCapabilityMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiOffCapabilityServerResponseModel>> Create(
			ApiOffCapabilityServerRequestModel model)
		{
			CreateResponse<ApiOffCapabilityServerResponseModel> response = ValidationResponseFactory<ApiOffCapabilityServerResponseModel>.CreateResponse(await this.OffCapabilityModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				OffCapability record = this.DalOffCapabilityMapper.MapModelToEntity(default(int), model);
				record = await this.OffCapabilityRepository.Create(record);

				response.SetRecord(this.DalOffCapabilityMapper.MapEntityToModel(record));
				await this.mediator.Publish(new OffCapabilityCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiOffCapabilityServerResponseModel>> Update(
			int id,
			ApiOffCapabilityServerRequestModel model)
		{
			var validationResult = await this.OffCapabilityModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				OffCapability record = this.DalOffCapabilityMapper.MapModelToEntity(id, model);
				await this.OffCapabilityRepository.Update(record);

				record = await this.OffCapabilityRepository.Get(id);

				ApiOffCapabilityServerResponseModel apiModel = this.DalOffCapabilityMapper.MapEntityToModel(record);
				await this.mediator.Publish(new OffCapabilityUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiOffCapabilityServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiOffCapabilityServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.OffCapabilityModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.OffCapabilityRepository.Delete(id);

				await this.mediator.Publish(new OffCapabilityDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiOfficerCapabilitiesServerResponseModel>> OfficerCapabilitiesByCapabilityId(int capabilityId, int limit = int.MaxValue, int offset = 0)
		{
			List<OfficerCapabilities> records = await this.OffCapabilityRepository.OfficerCapabilitiesByCapabilityId(capabilityId, limit, offset);

			return this.DalOfficerCapabilitiesMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>68c4bf1e344666abcf4f15c100c60fd1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/