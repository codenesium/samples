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
	public abstract class AbstractBOBreed
	{
		private IBreedRepository breedRepository;
		private IBreedModelValidator breedModelValidator;
		private ILogger logger;

		public AbstractBOBreed(
			ILogger logger,
			IBreedRepository breedRepository,
			IBreedModelValidator breedModelValidator)

		{
			this.breedRepository = breedRepository;
			this.breedModelValidator = breedModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			BreedModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.breedModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.breedRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			BreedModel model)
		{
			ActionResponse response = new ActionResponse(await this.breedModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.breedRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.breedModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.breedRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOBreed Get(int id)
		{
			return this.breedRepository.Get(id);
		}

		public virtual List<POCOBreed> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.breedRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>33b0e45c4d0ce20d2a9b9e8fadd84249</Hash>
</Codenesium>*/