using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractShiftService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IShiftRepository ShiftRepository { get; private set; }

		protected IApiShiftServerRequestModelValidator ShiftModelValidator { get; private set; }

		protected IDALShiftMapper DalShiftMapper { get; private set; }

		private ILogger logger;

		public AbstractShiftService(
			ILogger logger,
			MediatR.IMediator mediator,
			IShiftRepository shiftRepository,
			IApiShiftServerRequestModelValidator shiftModelValidator,
			IDALShiftMapper dalShiftMapper)
			: base()
		{
			this.ShiftRepository = shiftRepository;
			this.ShiftModelValidator = shiftModelValidator;
			this.DalShiftMapper = dalShiftMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiShiftServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Shift> records = await this.ShiftRepository.All(limit, offset, query);

			return this.DalShiftMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiShiftServerResponseModel> Get(int shiftID)
		{
			Shift record = await this.ShiftRepository.Get(shiftID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalShiftMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiShiftServerResponseModel>> Create(
			ApiShiftServerRequestModel model)
		{
			CreateResponse<ApiShiftServerResponseModel> response = ValidationResponseFactory<ApiShiftServerResponseModel>.CreateResponse(await this.ShiftModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Shift record = this.DalShiftMapper.MapModelToEntity(default(int), model);
				record = await this.ShiftRepository.Create(record);

				response.SetRecord(this.DalShiftMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ShiftCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiShiftServerResponseModel>> Update(
			int shiftID,
			ApiShiftServerRequestModel model)
		{
			var validationResult = await this.ShiftModelValidator.ValidateUpdateAsync(shiftID, model);

			if (validationResult.IsValid)
			{
				Shift record = this.DalShiftMapper.MapModelToEntity(shiftID, model);
				await this.ShiftRepository.Update(record);

				record = await this.ShiftRepository.Get(shiftID);

				ApiShiftServerResponseModel apiModel = this.DalShiftMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ShiftUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiShiftServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiShiftServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int shiftID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ShiftModelValidator.ValidateDeleteAsync(shiftID));

			if (response.Success)
			{
				await this.ShiftRepository.Delete(shiftID);

				await this.mediator.Publish(new ShiftDeletedNotification(shiftID));
			}

			return response;
		}

		public async virtual Task<ApiShiftServerResponseModel> ByName(string name)
		{
			Shift record = await this.ShiftRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalShiftMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<ApiShiftServerResponseModel> ByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime)
		{
			Shift record = await this.ShiftRepository.ByStartTimeEndTime(startTime, endTime);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalShiftMapper.MapEntityToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>67050afa8d6db399e9ba8d9f290fde8b</Hash>
</Codenesium>*/