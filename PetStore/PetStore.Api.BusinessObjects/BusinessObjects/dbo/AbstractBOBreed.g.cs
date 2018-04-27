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

		public virtual ApiResponse GetById(int id)
		{
			return this.breedRepository.GetById(id);
		}

		public virtual POCOBreed GetByIdDirect(int id)
		{
			return this.breedRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFBreed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.breedRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.breedRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOBreed> GetWhereDirect(Expression<Func<EFBreed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.breedRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>cf48c5df1e08e703f98c6c2748706698</Hash>
</Codenesium>*/