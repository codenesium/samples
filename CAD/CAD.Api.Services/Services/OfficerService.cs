using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class OfficerService : AbstractService, IOfficerService
	{
		private MediatR.IMediator mediator;

		protected IOfficerRepository OfficerRepository { get; private set; }

		protected IApiOfficerServerRequestModelValidator OfficerModelValidator { get; private set; }

		protected IDALOfficerMapper DalOfficerMapper { get; private set; }

		protected IDALNoteMapper DalNoteMapper { get; private set; }

		protected IDALOfficerCapabilitiesMapper DalOfficerCapabilitiesMapper { get; private set; }

		protected IDALUnitOfficerMapper DalUnitOfficerMapper { get; private set; }

		protected IDALVehicleOfficerMapper DalVehicleOfficerMapper { get; private set; }

		private ILogger logger;

		public OfficerService(
			ILogger<IOfficerService> logger,
			MediatR.IMediator mediator,
			IOfficerRepository officerRepository,
			IApiOfficerServerRequestModelValidator officerModelValidator,
			IDALOfficerMapper dalOfficerMapper,
			IDALNoteMapper dalNoteMapper,
			IDALOfficerCapabilitiesMapper dalOfficerCapabilitiesMapper,
			IDALUnitOfficerMapper dalUnitOfficerMapper,
			IDALVehicleOfficerMapper dalVehicleOfficerMapper)
			: base()
		{
			this.OfficerRepository = officerRepository;
			this.OfficerModelValidator = officerModelValidator;
			this.DalOfficerMapper = dalOfficerMapper;
			this.DalNoteMapper = dalNoteMapper;
			this.DalOfficerCapabilitiesMapper = dalOfficerCapabilitiesMapper;
			this.DalUnitOfficerMapper = dalUnitOfficerMapper;
			this.DalVehicleOfficerMapper = dalVehicleOfficerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiOfficerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Officer> records = await this.OfficerRepository.All(limit, offset, query);

			return this.DalOfficerMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiOfficerServerResponseModel> Get(int id)
		{
			Officer record = await this.OfficerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalOfficerMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiOfficerServerResponseModel>> Create(
			ApiOfficerServerRequestModel model)
		{
			CreateResponse<ApiOfficerServerResponseModel> response = ValidationResponseFactory<ApiOfficerServerResponseModel>.CreateResponse(await this.OfficerModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Officer record = this.DalOfficerMapper.MapModelToEntity(default(int), model);
				record = await this.OfficerRepository.Create(record);

				response.SetRecord(this.DalOfficerMapper.MapEntityToModel(record));
				await this.mediator.Publish(new OfficerCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiOfficerServerResponseModel>> Update(
			int id,
			ApiOfficerServerRequestModel model)
		{
			var validationResult = await this.OfficerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Officer record = this.DalOfficerMapper.MapModelToEntity(id, model);
				await this.OfficerRepository.Update(record);

				record = await this.OfficerRepository.Get(id);

				ApiOfficerServerResponseModel apiModel = this.DalOfficerMapper.MapEntityToModel(record);
				await this.mediator.Publish(new OfficerUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiOfficerServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiOfficerServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.OfficerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.OfficerRepository.Delete(id);

				await this.mediator.Publish(new OfficerDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiNoteServerResponseModel>> NotesByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			List<Note> records = await this.OfficerRepository.NotesByOfficerId(officerId, limit, offset);

			return this.DalNoteMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiOfficerCapabilitiesServerResponseModel>> OfficerCapabilitiesByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			List<OfficerCapabilities> records = await this.OfficerRepository.OfficerCapabilitiesByOfficerId(officerId, limit, offset);

			return this.DalOfficerCapabilitiesMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiUnitOfficerServerResponseModel>> UnitOfficersByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			List<UnitOfficer> records = await this.OfficerRepository.UnitOfficersByOfficerId(officerId, limit, offset);

			return this.DalUnitOfficerMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVehicleOfficerServerResponseModel>> VehicleOfficersByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0)
		{
			List<VehicleOfficer> records = await this.OfficerRepository.VehicleOfficersByOfficerId(officerId, limit, offset);

			return this.DalVehicleOfficerMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>6a23afd3e8d3d86901019e9164d00550</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/