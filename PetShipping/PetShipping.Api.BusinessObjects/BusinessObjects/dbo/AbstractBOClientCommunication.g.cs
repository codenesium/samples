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

		public virtual ApiResponse GetById(int id)
		{
			return this.clientCommunicationRepository.GetById(id);
		}

		public virtual POCOClientCommunication GetByIdDirect(int id)
		{
			return this.clientCommunicationRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.clientCommunicationRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.clientCommunicationRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOClientCommunication> GetWhereDirect(Expression<Func<EFClientCommunication, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.clientCommunicationRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>8ef54c641a033e33747e438aff0a0c79</Hash>
</Codenesium>*/