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
	public abstract class AbstractBODestination
	{
		private IDestinationRepository destinationRepository;
		private IApiDestinationModelValidator destinationModelValidator;
		private ILogger logger;

		public AbstractBODestination(
			ILogger logger,
			IDestinationRepository destinationRepository,
			IApiDestinationModelValidator destinationModelValidator)

		{
			this.destinationRepository = destinationRepository;
			this.destinationModelValidator = destinationModelValidator;
			this.logger = logger;
		}

		public virtual List<POCODestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.destinationRepository.All(skip, take, orderClause);
		}

		public virtual POCODestination Get(int id)
		{
			return this.destinationRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCODestination>> Create(
			ApiDestinationModel model)
		{
			CreateResponse<POCODestination> response = new CreateResponse<POCODestination>(await this.destinationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCODestination record = this.destinationRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiDestinationModel model)
		{
			ActionResponse response = new ActionResponse(await this.destinationModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.destinationRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.destinationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.destinationRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5c539b4f86529541a774d4825db3c96e</Hash>
</Codenesium>*/