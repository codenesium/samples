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

		public virtual async Task<CreateResponse<int>> Create(
			CountryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.countryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.countryRepository.Create(model);
				response.SetId(id);
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

		public virtual ApiResponse GetById(int id)
		{
			return this.countryRepository.GetById(id);
		}

		public virtual POCOCountry GetByIdDirect(int id)
		{
			return this.countryRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCountry, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCountry> GetWhereDirect(Expression<Func<EFCountry, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>116fc984cdbddb091ae349d3926b3d3a</Hash>
</Codenesium>*/