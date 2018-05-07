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
		private IHandlerModelValidator handlerModelValidator;
		private ILogger logger;

		public AbstractBOHandler(
			ILogger logger,
			IHandlerRepository handlerRepository,
			IHandlerModelValidator handlerModelValidator)

		{
			this.handlerRepository = handlerRepository;
			this.handlerModelValidator = handlerModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			HandlerModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.handlerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.handlerRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			HandlerModel model)
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

		public virtual POCOHandler Get(int id)
		{
			return this.handlerRepository.Get(id);
		}

		public virtual List<POCOHandler> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.handlerRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>2161a3ea949df83ef71ff04c87c0ed9f</Hash>
</Codenesium>*/