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
		private IApiAirTransportRequestModelValidator airTransportModelValidator;
		private IBOLAirTransportMapper airTransportMapper;
		private ILogger logger;

		public AbstractBOAirTransport(
			ILogger logger,
			IAirTransportRepository airTransportRepository,
			IApiAirTransportRequestModelValidator airTransportModelValidator,
			IBOLAirTransportMapper airTransportMapper)
			: base()

		{
			this.airTransportRepository = airTransportRepository;
			this.airTransportModelValidator = airTransportModelValidator;
			this.airTransportMapper = airTransportMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAirTransportResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.airTransportRepository.All(skip, take, orderClause);

			return this.airTransportMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiAirTransportResponseModel> Get(int airlineId)
		{
			var record = await airTransportRepository.Get(airlineId);

			return this.airTransportMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiAirTransportResponseModel>> Create(
			ApiAirTransportRequestModel model)
		{
			CreateResponse<ApiAirTransportResponseModel> response = new CreateResponse<ApiAirTransportResponseModel>(await this.airTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.airTransportMapper.MapModelToDTO(default (int), model);
				var record = await this.airTransportRepository.Create(dto);

				response.SetRecord(this.airTransportMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int airlineId,
			ApiAirTransportRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.airTransportModelValidator.ValidateUpdateAsync(airlineId, model));

			if (response.Success)
			{
				var dto = this.airTransportMapper.MapModelToDTO(airlineId, model);
				await this.airTransportRepository.Update(airlineId, dto);
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
    <Hash>5849b5b094a0396eeffe62e5d200bd2e</Hash>
</Codenesium>*/