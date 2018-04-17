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

		public virtual ApiResponse GetById(int shiftID)
		{
			return this.shiftRepository.GetById(shiftID);
		}

		public virtual POCOShift GetByIdDirect(int shiftID)
		{
			return this.shiftRepository.GetByIdDirect(shiftID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shiftRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shiftRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOShift> GetWhereDirect(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.shiftRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>f3020d33dc6c46180f087e97451d7273</Hash>
</Codenesium>*/