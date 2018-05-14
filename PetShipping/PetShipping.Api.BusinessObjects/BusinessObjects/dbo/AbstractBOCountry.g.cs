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
	public abstract class AbstractBOCountry
	{
		private ICountryRepository countryRepository;
		private ICountryModelValidator countryModelValidator;
		private ILogger logger;

		public AbstractBOCountry(
			ILogger logger,
			ICountryRepository countryRepository,
			ICountryModelValidator countryModelValidator)

		{
			this.countryRepository = countryRepository;
			this.countryModelValidator = countryModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOCountry> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRepository.All(skip, take, orderClause);
		}

		public virtual POCOCountry Get(int id)
		{
			return this.countryRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOCountry>> Create(
			CountryModel model)
		{
			CreateResponse<POCOCountry> response = new CreateResponse<POCOCountry>(await this.countryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCountry record = this.countryRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			CountryModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.countryRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.countryModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.countryRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>427e54d56b98df52ad164c5f59e5e7e2</Hash>
</Codenesium>*/