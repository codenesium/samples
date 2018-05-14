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
		private IApiBreedModelValidator breedModelValidator;
		private ILogger logger;

		public AbstractBOBreed(
			ILogger logger,
			IBreedRepository breedRepository,
			IApiBreedModelValidator breedModelValidator)

		{
			this.breedRepository = breedRepository;
			this.breedModelValidator = breedModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOBreed> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.breedRepository.All(skip, take, orderClause);
		}

		public virtual POCOBreed Get(int id)
		{
			return this.breedRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOBreed>> Create(
			ApiBreedModel model)
		{
			CreateResponse<POCOBreed> response = new CreateResponse<POCOBreed>(await this.breedModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOBreed record = this.breedRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiBreedModel model)
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
	}
}

/*<Codenesium>
    <Hash>fda81d768c17d046c0810b814186b72c</Hash>
</Codenesium>*/