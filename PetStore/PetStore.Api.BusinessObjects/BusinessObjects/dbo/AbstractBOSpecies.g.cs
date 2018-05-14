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

		public virtual List<POCOSpecies> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.speciesRepository.All(skip, take, orderClause);
		}

		public virtual POCOSpecies Get(int id)
		{
			return this.speciesRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOSpecies>> Create(
			SpeciesModel model)
		{
			CreateResponse<POCOSpecies> response = new CreateResponse<POCOSpecies>(await this.speciesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSpecies record = this.speciesRepository.Create(model);
				response.SetRecord(record);
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
	}
}

/*<Codenesium>
    <Hash>3f3ac2ac0fb17523ac3dc9d1e1bed1e3</Hash>
</Codenesium>*/