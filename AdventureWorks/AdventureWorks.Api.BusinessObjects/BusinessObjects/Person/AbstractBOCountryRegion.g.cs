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
	public abstract class AbstractBOCountryRegion: AbstractBOManager
	{
		private ICountryRegionRepository countryRegionRepository;
		private IApiCountryRegionModelValidator countryRegionModelValidator;
		private ILogger logger;

		public AbstractBOCountryRegion(
			ILogger logger,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionModelValidator countryRegionModelValidator)
			: base()

		{
			this.countryRegionRepository = countryRegionRepository;
			this.countryRegionModelValidator = countryRegionModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOCountryRegion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRegionRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOCountryRegion> Get(string countryRegionCode)
		{
			return this.countryRegionRepository.Get(countryRegionCode);
		}

		public virtual async Task<CreateResponse<POCOCountryRegion>> Create(
			ApiCountryRegionModel model)
		{
			CreateResponse<POCOCountryRegion> response = new CreateResponse<POCOCountryRegion>(await this.countryRegionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCountryRegion record = await this.countryRegionRepository.Create(model);

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
				await this.countryRegionRepository.Update(countryRegionCode, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string countryRegionCode)
		{
			ActionResponse response = new ActionResponse(await this.countryRegionModelValidator.ValidateDeleteAsync(countryRegionCode));

			if (response.Success)
			{
				await this.countryRegionRepository.Delete(countryRegionCode);
			}
			return response;
		}

		public async Task<POCOCountryRegion> GetName(string name)
		{
			return await this.countryRegionRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>2c046321d1550279202a2eb860179abe</Hash>
</Codenesium>*/