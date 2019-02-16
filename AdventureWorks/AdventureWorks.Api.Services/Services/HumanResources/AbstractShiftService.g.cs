using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractShiftService : AbstractService
	{
		private IMediator mediator;

		protected IShiftRepository ShiftRepository { get; private set; }

		protected IApiShiftServerRequestModelValidator ShiftModelValidator { get; private set; }

		protected IDALShiftMapper DalShiftMapper { get; private set; }

		private ILogger logger;

		public AbstractShiftService(
			ILogger logger,
			IMediator mediator,
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
			var records = await this.ShiftRepository.All(limit, offset, query);

			return this.DalShiftMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiShiftServerResponseModel> Get(int shiftID)
		{
			var record = await this.ShiftRepository.Get(shiftID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalShiftMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiShiftServerResponseModel>> Create(
			ApiShiftServerRequestModel model)
		{
			CreateResponse<ApiShiftServerResponseModel> response = ValidationResponseFactory<ApiShiftServerResponseModel>.CreateResponse(await this.ShiftModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalShiftMapper.MapModelToBO(default(int), model);
				var record = await this.ShiftRepository.Create(bo);

				response.SetRecord(this.DalShiftMapper.MapBOToModel(record));
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
				var bo = this.DalShiftMapper.MapModelToBO(shiftID, model);
				await this.ShiftRepository.Update(bo);

				var record = await this.ShiftRepository.Get(shiftID);

				var apiModel = this.DalShiftMapper.MapBOToModel(record);
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
				return this.DalShiftMapper.MapBOToModel(record);
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
				return this.DalShiftMapper.MapBOToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>898cc0fc45e29da8bd0255f588ffac1b</Hash>
</Codenesium>*/