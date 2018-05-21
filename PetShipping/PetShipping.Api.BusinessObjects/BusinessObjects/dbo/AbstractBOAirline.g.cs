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
	public abstract class AbstractBOAirline: AbstractBOManager
	{
		private IAirlineRepository airlineRepository;
		private IApiAirlineModelValidator airlineModelValidator;
		private ILogger logger;

		public AbstractBOAirline(
			ILogger logger,
			IAirlineRepository airlineRepository,
			IApiAirlineModelValidator airlineModelValidator)
			: base()

		{
			this.airlineRepository = airlineRepository;
			this.airlineModelValidator = airlineModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOAirline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.airlineRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOAirline> Get(int id)
		{
			return this.airlineRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOAirline>> Create(
			ApiAirlineModel model)
		{
			CreateResponse<POCOAirline> response = new CreateResponse<POCOAirline>(await this.airlineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOAirline record = await this.airlineRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiAirlineModel model)
		{
			ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.airlineRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.airlineRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6a9ce45d674402cb2ff4bce3e2d59e77</Hash>
</Codenesium>*/