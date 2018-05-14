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
		private IApiRateModelValidator rateModelValidator;
		private ILogger logger;

		public AbstractBORate(
			ILogger logger,
			IRateRepository rateRepository,
			IApiRateModelValidator rateModelValidator)

		{
			this.rateRepository = rateRepository;
			this.rateModelValidator = rateModelValidator;
			this.logger = logger;
		}

		public virtual List<POCORate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.rateRepository.All(skip, take, orderClause);
		}

		public virtual POCORate Get(int id)
		{
			return this.rateRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCORate>> Create(
			ApiRateModel model)
		{
			CreateResponse<POCORate> response = new CreateResponse<POCORate>(await this.rateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCORate record = this.rateRepository.Create(model);
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
	}
}

/*<Codenesium>
    <Hash>a5b53f006d8ebc4cbbdc4e13d08b26c4</Hash>
</Codenesium>*/