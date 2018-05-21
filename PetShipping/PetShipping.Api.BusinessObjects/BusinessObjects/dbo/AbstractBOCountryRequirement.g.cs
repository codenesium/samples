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
	public abstract class AbstractBOCountryRequirement: AbstractBOManager
	{
		private ICountryRequirementRepository countryRequirementRepository;
		private IApiCountryRequirementModelValidator countryRequirementModelValidator;
		private ILogger logger;

		public AbstractBOCountryRequirement(
			ILogger logger,
			ICountryRequirementRepository countryRequirementRepository,
			IApiCountryRequirementModelValidator countryRequirementModelValidator)
			: base()

		{
			this.countryRequirementRepository = countryRequirementRepository;
			this.countryRequirementModelValidator = countryRequirementModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOCountryRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.countryRequirementRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOCountryRequirement> Get(int id)
		{
			return this.countryRequirementRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOCountryRequirement>> Create(
			ApiCountryRequirementModel model)
		{
			CreateResponse<POCOCountryRequirement> response = new CreateResponse<POCOCountryRequirement>(await this.countryRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCountryRequirement record = await this.countryRequirementRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiCountryRequirementModel model)
		{
			ActionResponse response = new ActionResponse(await this.countryRequirementModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.countryRequirementRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.countryRequirementModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.countryRequirementRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c8671bdfddc4d53e17e02d260be65a8f</Hash>
</Codenesium>*/