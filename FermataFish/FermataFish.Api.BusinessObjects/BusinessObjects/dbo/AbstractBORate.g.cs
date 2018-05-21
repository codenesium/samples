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
	public abstract class AbstractBORate: AbstractBOManager
	{
		private IRateRepository rateRepository;
		private IApiRateModelValidator rateModelValidator;
		private ILogger logger;

		public AbstractBORate(
			ILogger logger,
			IRateRepository rateRepository,
			IApiRateModelValidator rateModelValidator)
			: base()

		{
			this.rateRepository = rateRepository;
			this.rateModelValidator = rateModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCORate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.rateRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCORate> Get(int id)
		{
			return this.rateRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCORate>> Create(
			ApiRateModel model)
		{
			CreateResponse<POCORate> response = new CreateResponse<POCORate>(await this.rateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCORate record = await this.rateRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiRateModel model)
		{
			ActionResponse response = new ActionResponse(await this.rateModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.rateRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.rateModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.rateRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d8be4ba1aeb55e745f3c8ad346c8eac6</Hash>
</Codenesium>*/