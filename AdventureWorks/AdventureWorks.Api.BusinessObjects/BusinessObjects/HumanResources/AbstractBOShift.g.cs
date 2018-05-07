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
	public abstract class AbstractBOShift
	{
		private IShiftRepository shiftRepository;
		private IShiftModelValidator shiftModelValidator;
		private ILogger logger;

		public AbstractBOShift(
			ILogger logger,
			IShiftRepository shiftRepository,
			IShiftModelValidator shiftModelValidator)

		{
			this.shiftRepository = shiftRepository;
			this.shiftModelValidator = shiftModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ShiftModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.shiftModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.shiftRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int shiftID,
			ShiftModel model)
		{
			ActionResponse response = new ActionResponse(await this.shiftModelValidator.ValidateUpdateAsync(shiftID, model));

			if (response.Success)
			{
				this.shiftRepository.Update(shiftID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int shiftID)
		{
			ActionResponse response = new ActionResponse(await this.shiftModelValidator.ValidateDeleteAsync(shiftID));

			if (response.Success)
			{
				this.shiftRepository.Delete(shiftID);
			}
			return response;
		}

		public virtual POCOShift Get(int shiftID)
		{
			return this.shiftRepository.Get(shiftID);
		}

		public virtual List<POCOShift> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shiftRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>92bdc187e946b1368faca5aebb285885</Hash>
</Codenesium>*/