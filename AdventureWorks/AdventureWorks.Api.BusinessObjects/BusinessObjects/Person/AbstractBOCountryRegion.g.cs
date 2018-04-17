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

		public virtual ApiResponse GetById(string countryRegionCode)
		{
			return this.countryRegionRepository.GetById(countryRegionCode);
		}

		public virtual POCOCountryRegion GetByIdDirect(string countryRegionCode)
		{
			return this.countryRegionRepository.GetByIdDirect(countryRegionCode);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRegionRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRegionRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCountryRegion> GetWhereDirect(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRegionRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>9a7069ea331961846f2a34c32e1ca771</Hash>
</Codenesium>*/