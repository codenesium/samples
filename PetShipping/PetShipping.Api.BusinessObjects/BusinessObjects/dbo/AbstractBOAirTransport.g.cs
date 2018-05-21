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
	public abstract class AbstractBOAirTransport: AbstractBOManager
	{
		private IAirTransportRepository airTransportRepository;
		private IApiAirTransportModelValidator airTransportModelValidator;
		private ILogger logger;

		public AbstractBOAirTransport(
			ILogger logger,
			IAirTransportRepository airTransportRepository,
			IApiAirTransportModelValidator airTransportModelValidator)
			: base()

		{
			this.airTransportRepository = airTransportRepository;
			this.airTransportModelValidator = airTransportModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOAirTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.airTransportRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOAirTransport> Get(int airlineId)
		{
			return this.airTransportRepository.Get(airlineId);
		}

		public virtual async Task<CreateResponse<POCOAirTransport>> Create(
			ApiAirTransportModel model)
		{
			CreateResponse<POCOAirTransport> response = new CreateResponse<POCOAirTransport>(await this.airTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOAirTransport record = await this.airTransportRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int airlineId,
			ApiAirTransportModel model)
		{
			ActionResponse response = new ActionResponse(await this.airTransportModelValidator.ValidateUpdateAsync(airlineId, model));

			if (response.Success)
			{
				await this.airTransportRepository.Update(airlineId, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int airlineId)
		{
			ActionResponse response = new ActionResponse(await this.airTransportModelValidator.ValidateDeleteAsync(airlineId));

			if (response.Success)
			{
				await this.airTransportRepository.Delete(airlineId);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fcffa30990fe699a03da30b93713d842</Hash>
</Codenesium>*/