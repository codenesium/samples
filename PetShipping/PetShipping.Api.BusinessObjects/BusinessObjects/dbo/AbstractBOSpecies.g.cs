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
	public abstract class AbstractBOSpecies
	{
		private ISpeciesRepository speciesRepository;
		private ISpeciesModelValidator speciesModelValidator;
		private ILogger logger;

		public AbstractBOSpecies(
			ILogger logger,
			ISpeciesRepository speciesRepository,
			ISpeciesModelValidator speciesModelValidator)

		{
			this.speciesRepository = speciesRepository;
			this.speciesModelValidator = speciesModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SpeciesModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.speciesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.speciesRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			SpeciesModel model)
		{
			ActionResponse response = new ActionResponse(await this.speciesModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.speciesRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.speciesModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.speciesRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOSpecies Get(int id)
		{
			return this.speciesRepository.Get(id);
		}

		public virtual List<POCOSpecies> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.speciesRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>83b70ddc30555f505e2d787ea00247d0</Hash>
</Codenesium>*/