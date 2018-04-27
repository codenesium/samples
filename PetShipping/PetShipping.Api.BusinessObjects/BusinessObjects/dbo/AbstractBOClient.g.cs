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
	public abstract class AbstractBOClient
	{
		private IClientRepository clientRepository;
		private IClientModelValidator clientModelValidator;
		private ILogger logger;

		public AbstractBOClient(
			ILogger logger,
			IClientRepository clientRepository,
			IClientModelValidator clientModelValidator)

		{
			this.clientRepository = clientRepository;
			this.clientModelValidator = clientModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ClientModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.clientModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.clientRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ClientModel model)
		{
			ActionResponse response = new ActionResponse(await this.clientModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.clientRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.clientModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.clientRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.clientRepository.GetById(id);
		}

		public virtual POCOClient GetByIdDirect(int id)
		{
			return this.clientRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFClient, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.clientRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.clientRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOClient> GetWhereDirect(Expression<Func<EFClient, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.clientRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>ec635c8d6896465eca7d41a17e20d139</Hash>
</Codenesium>*/