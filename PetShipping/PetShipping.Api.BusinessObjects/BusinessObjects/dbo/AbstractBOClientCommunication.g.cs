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
	public abstract class AbstractBOClientCommunication: AbstractBOManager
	{
		private IClientCommunicationRepository clientCommunicationRepository;
		private IApiClientCommunicationModelValidator clientCommunicationModelValidator;
		private ILogger logger;

		public AbstractBOClientCommunication(
			ILogger logger,
			IClientCommunicationRepository clientCommunicationRepository,
			IApiClientCommunicationModelValidator clientCommunicationModelValidator)
			: base()

		{
			this.clientCommunicationRepository = clientCommunicationRepository;
			this.clientCommunicationModelValidator = clientCommunicationModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOClientCommunication>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.clientCommunicationRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOClientCommunication> Get(int id)
		{
			return this.clientCommunicationRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOClientCommunication>> Create(
			ApiClientCommunicationModel model)
		{
			CreateResponse<POCOClientCommunication> response = new CreateResponse<POCOClientCommunication>(await this.clientCommunicationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOClientCommunication record = await this.clientCommunicationRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiClientCommunicationModel model)
		{
			ActionResponse response = new ActionResponse(await this.clientCommunicationModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.clientCommunicationRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.clientCommunicationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.clientCommunicationRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f229c8a7d8c1a9970bcc779b7ccbd82a</Hash>
</Codenesium>*/