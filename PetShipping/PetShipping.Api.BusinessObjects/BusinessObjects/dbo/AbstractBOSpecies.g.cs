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

		public virtual ApiResponse GetById(int id)
		{
			return this.speciesRepository.GetById(id);
		}

		public virtual POCOSpecies GetByIdDirect(int id)
		{
			return this.speciesRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSpecies, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.speciesRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.speciesRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSpecies> GetWhereDirect(Expression<Func<EFSpecies, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.speciesRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>18db82daa6e45d62cc150a721cae9e62</Hash>
</Codenesium>*/