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
	public abstract class AbstractBOHandler
	{
		private IHandlerRepository handlerRepository;
		private IApiHandlerModelValidator handlerModelValidator;
		private ILogger logger;

		public AbstractBOHandler(
			ILogger logger,
			IHandlerRepository handlerRepository,
			IApiHandlerModelValidator handlerModelValidator)

		{
			this.handlerRepository = handlerRepository;
			this.handlerModelValidator = handlerModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOHandler> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.handlerRepository.All(skip, take, orderClause);
		}

		public virtual POCOHandler Get(int id)
		{
			return this.handlerRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOHandler>> Create(
			ApiHandlerModel model)
		{
			CreateResponse<POCOHandler> response = new CreateResponse<POCOHandler>(await this.handlerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOHandler record = this.handlerRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiHandlerModel model)
		{
			ActionResponse response = new ActionResponse(await this.handlerModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.handlerRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.handlerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.handlerRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7a03777b608565d55e6fb4a49345794c</Hash>
</Codenesium>*/