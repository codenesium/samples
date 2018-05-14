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
	public abstract class AbstractBOAirline
	{
		private IAirlineRepository airlineRepository;
		private IAirlineModelValidator airlineModelValidator;
		private ILogger logger;

		public AbstractBOAirline(
			ILogger logger,
			IAirlineRepository airlineRepository,
			IAirlineModelValidator airlineModelValidator)

		{
			this.airlineRepository = airlineRepository;
			this.airlineModelValidator = airlineModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOAirline> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.airlineRepository.All(skip, take, orderClause);
		}

		public virtual POCOAirline Get(int id)
		{
			return this.airlineRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOAirline>> Create(
			AirlineModel model)
		{
			CreateResponse<POCOAirline> response = new CreateResponse<POCOAirline>(await this.airlineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOAirline record = this.airlineRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			AirlineModel model)
		{
			ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.airlineRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.airlineRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>52a82976b383a2238ccbe65cb76653e6</Hash>
</Codenesium>*/