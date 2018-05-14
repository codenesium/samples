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
		private IApiClientModelValidator clientModelValidator;
		private ILogger logger;

		public AbstractBOClient(
			ILogger logger,
			IClientRepository clientRepository,
			IApiClientModelValidator clientModelValidator)

		{
			this.clientRepository = clientRepository;
			this.clientModelValidator = clientModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOClient> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.clientRepository.All(skip, take, orderClause);
		}

		public virtual POCOClient Get(int id)
		{
			return this.clientRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOClient>> Create(
			ApiClientModel model)
		{
			CreateResponse<POCOClient> response = new CreateResponse<POCOClient>(await this.clientModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOClient record = this.clientRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiClientModel model)
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
	}
}

/*<Codenesium>
    <Hash>3a479f1f40d91924686b4bf0d83546e8</Hash>
</Codenesium>*/