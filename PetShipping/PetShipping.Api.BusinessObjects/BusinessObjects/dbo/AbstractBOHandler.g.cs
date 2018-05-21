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
	public abstract class AbstractBOHandler: AbstractBOManager
	{
		private IHandlerRepository handlerRepository;
		private IApiHandlerModelValidator handlerModelValidator;
		private ILogger logger;

		public AbstractBOHandler(
			ILogger logger,
			IHandlerRepository handlerRepository,
			IApiHandlerModelValidator handlerModelValidator)
			: base()

		{
			this.handlerRepository = handlerRepository;
			this.handlerModelValidator = handlerModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOHandler>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.handlerRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOHandler> Get(int id)
		{
			return this.handlerRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOHandler>> Create(
			ApiHandlerModel model)
		{
			CreateResponse<POCOHandler> response = new CreateResponse<POCOHandler>(await this.handlerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOHandler record = await this.handlerRepository.Create(model);

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
				await this.handlerRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.handlerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.handlerRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1d2a78cd20676a7609a053706d135b18</Hash>
</Codenesium>*/