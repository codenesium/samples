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
	public abstract class AbstractBOPet
	{
		private IPetRepository petRepository;
		private IApiPetModelValidator petModelValidator;
		private ILogger logger;

		public AbstractBOPet(
			ILogger logger,
			IPetRepository petRepository,
			IApiPetModelValidator petModelValidator)

		{
			this.petRepository = petRepository;
			this.petModelValidator = petModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOPet> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.petRepository.All(skip, take, orderClause);
		}

		public virtual POCOPet Get(int id)
		{
			return this.petRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPet>> Create(
			ApiPetModel model)
		{
			CreateResponse<POCOPet> response = new CreateResponse<POCOPet>(await this.petModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPet record = this.petRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPetModel model)
		{
			ActionResponse response = new ActionResponse(await this.petModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.petRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.petModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.petRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>20d09005f8b75dbf312c8f73ce4cc545</Hash>
</Codenesium>*/