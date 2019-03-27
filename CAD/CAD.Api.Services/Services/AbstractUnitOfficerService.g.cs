using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractUnitOfficerService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IUnitOfficerRepository UnitOfficerRepository { get; private set; }

		protected IApiUnitOfficerServerRequestModelValidator UnitOfficerModelValidator { get; private set; }

		protected IDALUnitOfficerMapper DalUnitOfficerMapper { get; private set; }

		private ILogger logger;

		public AbstractUnitOfficerService(
			ILogger logger,
			MediatR.IMediator mediator,
			IUnitOfficerRepository unitOfficerRepository,
			IApiUnitOfficerServerRequestModelValidator unitOfficerModelValidator,
			IDALUnitOfficerMapper dalUnitOfficerMapper)
			: base()
		{
			this.UnitOfficerRepository = unitOfficerRepository;
			this.UnitOfficerModelValidator = unitOfficerModelValidator;
			this.DalUnitOfficerMapper = dalUnitOfficerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiUnitOfficerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<UnitOfficer> records = await this.UnitOfficerRepository.All(limit, offset, query);

			return this.DalUnitOfficerMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiUnitOfficerServerResponseModel> Get(int id)
		{
			UnitOfficer record = await this.UnitOfficerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalUnitOfficerMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiUnitOfficerServerResponseModel>> Create(
			ApiUnitOfficerServerRequestModel model)
		{
			CreateResponse<ApiUnitOfficerServerResponseModel> response = ValidationResponseFactory<ApiUnitOfficerServerResponseModel>.CreateResponse(await this.UnitOfficerModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				UnitOfficer record = this.DalUnitOfficerMapper.MapModelToEntity(default(int), model);
				record = await this.UnitOfficerRepository.Create(record);

				response.SetRecord(this.DalUnitOfficerMapper.MapEntityToModel(record));
				await this.mediator.Publish(new UnitOfficerCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUnitOfficerServerResponseModel>> Update(
			int id,
			ApiUnitOfficerServerRequestModel model)
		{
			var validationResult = await this.UnitOfficerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				UnitOfficer record = this.DalUnitOfficerMapper.MapModelToEntity(id, model);
				await this.UnitOfficerRepository.Update(record);

				record = await this.UnitOfficerRepository.Get(id);

				ApiUnitOfficerServerResponseModel apiModel = this.DalUnitOfficerMapper.MapEntityToModel(record);
				await this.mediator.Publish(new UnitOfficerUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiUnitOfficerServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiUnitOfficerServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.UnitOfficerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.UnitOfficerRepository.Delete(id);

				await this.mediator.Publish(new UnitOfficerDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dd72ae947d163d13a0a1718ffacf7aad</Hash>
</Codenesium>*/