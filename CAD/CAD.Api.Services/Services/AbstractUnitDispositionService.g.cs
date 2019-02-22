using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractUnitDispositionService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IUnitDispositionRepository UnitDispositionRepository { get; private set; }

		protected IApiUnitDispositionServerRequestModelValidator UnitDispositionModelValidator { get; private set; }

		protected IDALUnitDispositionMapper DalUnitDispositionMapper { get; private set; }

		private ILogger logger;

		public AbstractUnitDispositionService(
			ILogger logger,
			MediatR.IMediator mediator,
			IUnitDispositionRepository unitDispositionRepository,
			IApiUnitDispositionServerRequestModelValidator unitDispositionModelValidator,
			IDALUnitDispositionMapper dalUnitDispositionMapper)
			: base()
		{
			this.UnitDispositionRepository = unitDispositionRepository;
			this.UnitDispositionModelValidator = unitDispositionModelValidator;
			this.DalUnitDispositionMapper = dalUnitDispositionMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiUnitDispositionServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<UnitDisposition> records = await this.UnitDispositionRepository.All(limit, offset, query);

			return this.DalUnitDispositionMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiUnitDispositionServerResponseModel> Get(int id)
		{
			UnitDisposition record = await this.UnitDispositionRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalUnitDispositionMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiUnitDispositionServerResponseModel>> Create(
			ApiUnitDispositionServerRequestModel model)
		{
			CreateResponse<ApiUnitDispositionServerResponseModel> response = ValidationResponseFactory<ApiUnitDispositionServerResponseModel>.CreateResponse(await this.UnitDispositionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				UnitDisposition record = this.DalUnitDispositionMapper.MapModelToEntity(default(int), model);
				record = await this.UnitDispositionRepository.Create(record);

				response.SetRecord(this.DalUnitDispositionMapper.MapEntityToModel(record));
				await this.mediator.Publish(new UnitDispositionCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUnitDispositionServerResponseModel>> Update(
			int id,
			ApiUnitDispositionServerRequestModel model)
		{
			var validationResult = await this.UnitDispositionModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				UnitDisposition record = this.DalUnitDispositionMapper.MapModelToEntity(id, model);
				await this.UnitDispositionRepository.Update(record);

				record = await this.UnitDispositionRepository.Get(id);

				ApiUnitDispositionServerResponseModel apiModel = this.DalUnitDispositionMapper.MapEntityToModel(record);
				await this.mediator.Publish(new UnitDispositionUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiUnitDispositionServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiUnitDispositionServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.UnitDispositionModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.UnitDispositionRepository.Delete(id);

				await this.mediator.Publish(new UnitDispositionDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c1319be7a4bd9797e10f2b2ec2a56286</Hash>
</Codenesium>*/