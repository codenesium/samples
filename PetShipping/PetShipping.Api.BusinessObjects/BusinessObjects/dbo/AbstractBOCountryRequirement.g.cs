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
	public abstract class AbstractBOCountryRequirement
	{
		private ICountryRequirementRepository countryRequirementRepository;
		private ICountryRequirementModelValidator countryRequirementModelValidator;
		private ILogger logger;

		public AbstractBOCountryRequirement(
			ILogger logger,
			ICountryRequirementRepository countryRequirementRepository,
			ICountryRequirementModelValidator countryRequirementModelValidator)

		{
			this.countryRequirementRepository = countryRequirementRepository;
			this.countryRequirementModelValidator = countryRequirementModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			CountryRequirementModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.countryRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.countryRequirementRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			CountryRequirementModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryRequirementModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.countryRequirementRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.countryRequirementModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.countryRequirementRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOCountryRequirement Get(int id)
		{
			return this.countryRequirementRepository.Get(id);
		}

		public virtual List<POCOCountryRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRequirementRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>66bcdc2c6954ba226d209c5c20a63054</Hash>
</Codenesium>*/