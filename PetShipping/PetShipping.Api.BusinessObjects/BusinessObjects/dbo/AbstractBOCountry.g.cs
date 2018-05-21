using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOCountry: AbstractBOManager
	{
		private ICountryRepository countryRepository;
		private IApiCountryModelValidator countryModelValidator;
		private ILogger logger;

		public AbstractBOCountry(
			ILogger logger,
			ICountryRepository countryRepository,
			IApiCountryModelValidator countryModelValidator)
			: base()

		{
			this.countryRepository = countryRepository;
			this.countryModelValidator = countryModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOCountry>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOCountry> Get(int id)
		{
			return this.countryRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOCountry>> Create(
			ApiCountryModel model)
		{
			CreateResponse<POCOCountry> response = new CreateResponse<POCOCountry>(await this.countryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCountry record = await this.countryRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiCountryModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.countryRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.countryModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.countryRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5a46e990c60fbcadc56a8f6bbdbf6a2c</Hash>
</Codenesium>*/