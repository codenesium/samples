using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractUnitService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IUnitRepository UnitRepository { get; private set; }

		protected IApiUnitServerRequestModelValidator UnitModelValidator { get; private set; }

		protected IDALUnitMapper DalUnitMapper { get; private set; }

		protected IDALCallAssignmentMapper DalCallAssignmentMapper { get; private set; }

		protected IDALUnitOfficerMapper DalUnitOfficerMapper { get; private set; }

		private ILogger logger;

		public AbstractUnitService(
			ILogger logger,
			MediatR.IMediator mediator,
			IUnitRepository unitRepository,
			IApiUnitServerRequestModelValidator unitModelValidator,
			IDALUnitMapper dalUnitMapper,
			IDALCallAssignmentMapper dalCallAssignmentMapper,
			IDALUnitOfficerMapper dalUnitOfficerMapper)
			: base()
		{
			this.UnitRepository = unitRepository;
			this.UnitModelValidator = unitModelValidator;
			this.DalUnitMapper = dalUnitMapper;
			this.DalCallAssignmentMapper = dalCallAssignmentMapper;
			this.DalUnitOfficerMapper = dalUnitOfficerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiUnitServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Unit> records = await this.UnitRepository.All(limit, offset, query);

			return this.DalUnitMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiUnitServerResponseModel> Get(int id)
		{
			Unit record = await this.UnitRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalUnitMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiUnitServerResponseModel>> Create(
			ApiUnitServerRequestModel model)
		{
			CreateResponse<ApiUnitServerResponseModel> response = ValidationResponseFactory<ApiUnitServerResponseModel>.CreateResponse(await this.UnitModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Unit record = this.DalUnitMapper.MapModelToEntity(default(int), model);
				record = await this.UnitRepository.Create(record);

				response.SetRecord(this.DalUnitMapper.MapEntityToModel(record));
				await this.mediator.Publish(new UnitCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUnitServerResponseModel>> Update(
			int id,
			ApiUnitServerRequestModel model)
		{
			var validationResult = await this.UnitModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Unit record = this.DalUnitMapper.MapModelToEntity(id, model);
				await this.UnitRepository.Update(record);

				record = await this.UnitRepository.Get(id);

				ApiUnitServerResponseModel apiModel = this.DalUnitMapper.MapEntityToModel(record);
				await this.mediator.Publish(new UnitUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiUnitServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiUnitServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.UnitModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.UnitRepository.Delete(id);

				await this.mediator.Publish(new UnitDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCallAssignmentServerResponseModel>> CallAssignmentsByUnitId(int unitId, int limit = int.MaxValue, int offset = 0)
		{
			List<CallAssignment> records = await this.UnitRepository.CallAssignmentsByUnitId(unitId, limit, offset);

			return this.DalCallAssignmentMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiUnitOfficerServerResponseModel>> UnitOfficersByUnitId(int unitId, int limit = int.MaxValue, int offset = 0)
		{
			List<UnitOfficer> records = await this.UnitRepository.UnitOfficersByUnitId(unitId, limit, offset);

			return this.DalUnitOfficerMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>7dc3d64b1a7bbc5fb3ddb175ed18fe51</Hash>
</Codenesium>*/