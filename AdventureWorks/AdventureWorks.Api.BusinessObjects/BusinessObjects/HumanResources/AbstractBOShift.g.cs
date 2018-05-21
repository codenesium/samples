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
		private IApiShiftModelValidator shiftModelValidator;
		private ILogger logger;

		public AbstractBOShift(
			ILogger logger,
			IShiftRepository shiftRepository,
			IApiShiftModelValidator shiftModelValidator)
			: base()

		{
			this.shiftRepository = shiftRepository;
			this.shiftModelValidator = shiftModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOShift>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shiftRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOShift> Get(int shiftID)
		{
			return this.shiftRepository.Get(shiftID);
		}

		public virtual async Task<CreateResponse<POCOShift>> Create(
			ApiShiftModel model)
		{
			CreateResponse<POCOShift> response = new CreateResponse<POCOShift>(await this.shiftModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOShift record = await this.shiftRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int shiftID,
			ApiShiftModel model)
		{
			ActionResponse response = new ActionResponse(await this.shiftModelValidator.ValidateUpdateAsync(shiftID, model));

			if (response.Success)
			{
				await this.shiftRepository.Update(shiftID, model);
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

		public async Task<POCOShift> GetName(string name)
		{
			return await this.shiftRepository.GetName(name);
		}
		public async Task<POCOShift> GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime)
		{
			return await this.shiftRepository.GetStartTimeEndTime(startTime,endTime);
		}
	}
}

/*<Codenesium>
    <Hash>f00b308e3d7eb544619d5845509ae7df</Hash>
</Codenesium>*/