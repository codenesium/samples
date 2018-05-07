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
	public abstract class AbstractBOCountryRegion
	{
		private ICountryRegionRepository countryRegionRepository;
		private ICountryRegionModelValidator countryRegionModelValidator;
		private ILogger logger;

		public AbstractBOCountryRegion(
			ILogger logger,
			ICountryRegionRepository countryRegionRepository,
			ICountryRegionModelValidator countryRegionModelValidator)

		{
			this.countryRegionRepository = countryRegionRepository;
			this.countryRegionModelValidator = countryRegionModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<string>> Create(
			CountryRegionModel model)
		{
			CreateResponse<string> response = new CreateResponse<string>(await this.countryRegionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				string id = this.countryRegionRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string countryRegionCode,
			CountryRegionModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryRegionModelValidator.ValidateUpdateAsync(countryRegionCode, model));

			if (response.Success)
			{
				this.countryRegionRepository.Update(countryRegionCode, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string countryRegionCode)
		{
			ActionResponse response = new ActionResponse(await this.countryRegionModelValidator.ValidateDeleteAsync(countryRegionCode));

			if (response.Success)
			{
				this.countryRegionRepository.Delete(countryRegionCode);
			}
			return response;
		}

		public virtual POCOCountryRegion Get(string countryRegionCode)
		{
			return this.countryRegionRepository.Get(countryRegionCode);
		}

		public virtual List<POCOCountryRegion> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRegionRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>bdb82aaa1f5e545c1ea37475121c600d</Hash>
</Codenesium>*/