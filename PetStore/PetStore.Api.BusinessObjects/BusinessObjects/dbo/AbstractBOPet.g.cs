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
		private IPetModelValidator petModelValidator;
		private ILogger logger;

		public AbstractBOPet(
			ILogger logger,
			IPetRepository petRepository,
			IPetModelValidator petModelValidator)

		{
			this.petRepository = petRepository;
			this.petModelValidator = petModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PetModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.petModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.petRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PetModel model)
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

		public virtual ApiResponse GetById(int id)
		{
			return this.petRepository.GetById(id);
		}

		public virtual POCOPet GetByIdDirect(int id)
		{
			return this.petRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPet, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.petRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.petRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPet> GetWhereDirect(Expression<Func<EFPet, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.petRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>7b156a60d2f9815d7c7762a9b87ecad0</Hash>
</Codenesium>*/