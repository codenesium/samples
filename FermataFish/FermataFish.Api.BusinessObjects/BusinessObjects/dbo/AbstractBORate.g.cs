using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBORate
	{
		private IRateRepository rateRepository;
		private IRateModelValidator rateModelValidator;
		private ILogger logger;

		public AbstractBORate(
			ILogger logger,
			IRateRepository rateRepository,
			IRateModelValidator rateModelValidator)

		{
			this.rateRepository = rateRepository;
			this.rateModelValidator = rateModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			RateModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.rateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.rateRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			RateModel model)
		{
			ActionResponse response = new ActionResponse(await this.rateModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.rateRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.rateModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.rateRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.rateRepository.GetById(id);
		}

		public virtual POCORate GetByIdDirect(int id)
		{
			return this.rateRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.rateRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.rateRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCORate> GetWhereDirect(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.rateRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>26f2df5082b3cddc8195bc0719bf7b8c</Hash>
</Codenesium>*/