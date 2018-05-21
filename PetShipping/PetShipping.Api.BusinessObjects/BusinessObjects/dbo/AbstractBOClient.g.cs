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
	public abstract class AbstractBOClient: AbstractBOManager
	{
		private IClientRepository clientRepository;
		private IApiClientModelValidator clientModelValidator;
		private ILogger logger;

		public AbstractBOClient(
			ILogger logger,
			IClientRepository clientRepository,
			IApiClientModelValidator clientModelValidator)
			: base()

		{
			this.clientRepository = clientRepository;
			this.clientModelValidator = clientModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOClient>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.clientRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOClient> Get(int id)
		{
			return this.clientRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOClient>> Create(
			ApiClientModel model)
		{
			CreateResponse<POCOClient> response = new CreateResponse<POCOClient>(await this.clientModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOClient record = await this.clientRepository.Create(model);

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
				await this.clientRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.clientModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.clientRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3237d4b10dd1f3be0771cf8776ba1cd7</Hash>
</Codenesium>*/