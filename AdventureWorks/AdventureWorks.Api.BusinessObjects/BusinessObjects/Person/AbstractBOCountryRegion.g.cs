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
		private IApiCountryRegionModelValidator countryRegionModelValidator;
		private ILogger logger;

		public AbstractBOCountryRegion(
			ILogger logger,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionModelValidator countryRegionModelValidator)

		{
			this.countryRegionRepository = countryRegionRepository;
			this.countryRegionModelValidator = countryRegionModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOCountryRegion> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRegionRepository.All(skip, take, orderClause);
		}

		public virtual POCOCountryRegion Get(string countryRegionCode)
		{
			return this.countryRegionRepository.Get(countryRegionCode);
		}

		public virtual async Task<CreateResponse<POCOCountryRegion>> Create(
			ApiCountryRegionModel model)
		{
			CreateResponse<POCOCountryRegion> response = new CreateResponse<POCOCountryRegion>(await this.countryRegionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCountryRegion record = this.countryRegionRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string countryRegionCode,
			ApiCountryRegionModel model)
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

		public POCOCountryRegion GetName(string name)
		{
			return this.countryRegionRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>cdb93edbf1e761464cf9928a61d68d32</Hash>
</Codenesium>*/