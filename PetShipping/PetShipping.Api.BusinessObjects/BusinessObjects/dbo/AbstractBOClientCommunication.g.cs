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
	public abstract class AbstractBOClientCommunication
	{
		private IClientCommunicationRepository clientCommunicationRepository;
		private IClientCommunicationModelValidator clientCommunicationModelValidator;
		private ILogger logger;

		public AbstractBOClientCommunication(
			ILogger logger,
			IClientCommunicationRepository clientCommunicationRepository,
			IClientCommunicationModelValidator clientCommunicationModelValidator)

		{
			this.clientCommunicationRepository = clientCommunicationRepository;
			this.clientCommunicationModelValidator = clientCommunicationModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ClientCommunicationModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.clientCommunicationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.clientCommunicationRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ClientCommunicationModel model)
		{
			ActionResponse response = new ActionResponse(await this.clientCommunicationModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.clientCommunicationRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.clientCommunicationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.clientCommunicationRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOClientCommunication Get(int id)
		{
			return this.clientCommunicationRepository.Get(id);
		}

		public virtual List<POCOClientCommunication> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.clientCommunicationRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>7754f3ff17447a4351554d601b5b7e18</Hash>
</Codenesium>*/