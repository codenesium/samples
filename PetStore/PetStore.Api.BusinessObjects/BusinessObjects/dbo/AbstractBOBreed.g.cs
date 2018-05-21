using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOBreed: AbstractBOManager
	{
		private IBreedRepository breedRepository;
		private IApiBreedModelValidator breedModelValidator;
		private ILogger logger;

		public AbstractBOBreed(
			ILogger logger,
			IBreedRepository breedRepository,
			IApiBreedModelValidator breedModelValidator)
			: base()

		{
			this.breedRepository = breedRepository;
			this.breedModelValidator = breedModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOBreed>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.breedRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOBreed> Get(int id)
		{
			return this.breedRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOBreed>> Create(
			ApiBreedModel model)
		{
			CreateResponse<POCOBreed> response = new CreateResponse<POCOBreed>(await this.breedModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOBreed record = await this.breedRepository.Create(model);

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
				await this.breedRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.breedModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.breedRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>feb3d5b92e16d3ef979d0be6512221de</Hash>
</Codenesium>*/