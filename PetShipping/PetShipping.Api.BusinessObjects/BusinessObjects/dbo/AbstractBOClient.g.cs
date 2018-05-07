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

		public virtual POCOClient Get(int id)
		{
			return this.clientRepository.Get(id);
		}

		public virtual List<POCOClient> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.clientRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>130db0e6bd19c4e41f393a291e88dc2a</Hash>
</Codenesium>*/