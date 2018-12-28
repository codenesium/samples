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

		protected IBOLShiftMapper BolShiftMapper { get; private set; }

		protected IDALShiftMapper DalShiftMapper { get; private set; }

		private ILogger logger;

		public AbstractShiftService(
			ILogger logger,
			IMediator mediator,
			IShiftRepository shiftRepository,
			IApiShiftServerRequestModelValidator shiftModelValidator,
			IBOLShiftMapper bolShiftMapper,
			IDALShiftMapper dalShiftMapper)
			: base()
		{
			this.ShiftRepository = shiftRepository;
			this.ShiftModelValidator = shiftModelValidator;
			this.BolShiftMapper = bolShiftMapper;
			this.DalShiftMapper = dalShiftMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiShiftServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ShiftRepository.All(limit, offset);

			return this.BolShiftMapper.MapBOToModel(this.DalShiftMapper.MapEFToBO(records));
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
				return this.BolShiftMapper.MapBOToModel(this.DalShiftMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiShiftServerResponseModel>> Create(
			ApiShiftServerRequestModel model)
		{
			CreateResponse<ApiShiftServerResponseModel> response = ValidationResponseFactory<ApiShiftServerResponseModel>.CreateResponse(await this.ShiftModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolShiftMapper.MapModelToBO(default(int), model);
				var record = await this.ShiftRepository.Create(this.DalShiftMapper.MapBOToEF(bo));

				var businessObject = this.DalShiftMapper.MapEFToBO(record);
				response.SetRecord(this.BolShiftMapper.MapBOToModel(businessObject));
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
				var bo = this.BolShiftMapper.MapModelToBO(shiftID, model);
				await this.ShiftRepository.Update(this.DalShiftMapper.MapBOToEF(bo));

				var record = await this.ShiftRepository.Get(shiftID);

				var businessObject = this.DalShiftMapper.MapEFToBO(record);
				var apiModel = this.BolShiftMapper.MapBOToModel(businessObject);
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
				return this.BolShiftMapper.MapBOToModel(this.DalShiftMapper.MapEFToBO(record));
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
				return this.BolShiftMapper.MapBOToModel(this.DalShiftMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>4692a4f124babad71af2f3c9e10ddd3b</Hash>
</Codenesium>*/