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
		private IDestinationModelValidator destinationModelValidator;
		private ILogger logger;

		public AbstractBODestination(
			ILogger logger,
			IDestinationRepository destinationRepository,
			IDestinationModelValidator destinationModelValidator)

		{
			this.destinationRepository = destinationRepository;
			this.destinationModelValidator = destinationModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			DestinationModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.destinationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.destinationRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			DestinationModel model)
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

		public virtual POCODestination Get(int id)
		{
			return this.destinationRepository.Get(id);
		}

		public virtual List<POCODestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.destinationRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>9ab769d55d5ac2af0d490a6f5bbb3bbc</Hash>
</Codenesium>*/