using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOShift: AbstractBOManager
	{
		private IShiftRepository shiftRepository;
		private IApiShiftRequestModelValidator shiftModelValidator;
		private IBOLShiftMapper shiftMapper;
		private ILogger logger;

		public AbstractBOShift(
			ILogger logger,
			IShiftRepository shiftRepository,
			IApiShiftRequestModelValidator shiftModelValidator,
			IBOLShiftMapper shiftMapper)
			: base()

		{
			this.shiftRepository = shiftRepository;
			this.shiftModelValidator = shiftModelValidator;
			this.shiftMapper = shiftMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiShiftResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.shiftRepository.All(skip, take, orderClause);

			return this.shiftMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiShiftResponseModel> Get(int shiftID)
		{
			var record = await shiftRepository.Get(shiftID);

			return this.shiftMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiShiftResponseModel>> Create(
			ApiShiftRequestModel model)
		{
			CreateResponse<ApiShiftResponseModel> response = new CreateResponse<ApiShiftResponseModel>(await this.shiftModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.shiftMapper.MapModelToDTO(default (int), model);
				var record = await this.shiftRepository.Create(dto);

				response.SetRecord(this.shiftMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int shiftID,
			ApiShiftRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.shiftModelValidator.ValidateUpdateAsync(shiftID, model));

			if (response.Success)
			{
				var dto = this.shiftMapper.MapModelToDTO(shiftID, model);
				await this.shiftRepository.Update(shiftID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int shiftID)
		{
			ActionResponse response = new ActionResponse(await this.shiftModelValidator.ValidateDeleteAsync(shiftID));

			if (response.Success)
			{
				await this.shiftRepository.Delete(shiftID);
			}
			return response;
		}

		public async Task<ApiShiftResponseModel> GetName(string name)
		{
			DTOShift record = await this.shiftRepository.GetName(name);

			return this.shiftMapper.MapDTOToModel(record);
		}
		public async Task<ApiShiftResponseModel> GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime)
		{
			DTOShift record = await this.shiftRepository.GetStartTimeEndTime(startTime,endTime);

			return this.shiftMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>9037e29b086da1f896d5706458fe0e83</Hash>
</Codenesium>*/