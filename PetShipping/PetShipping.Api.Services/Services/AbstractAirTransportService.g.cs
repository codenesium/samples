using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractAirTransportService : AbstractService
	{
		protected IAirTransportRepository AirTransportRepository { get; private set; }

		protected IApiAirTransportRequestModelValidator AirTransportModelValidator { get; private set; }

		protected IBOLAirTransportMapper BolAirTransportMapper { get; private set; }

		protected IDALAirTransportMapper DalAirTransportMapper { get; private set; }

		private ILogger logger;

		public AbstractAirTransportService(
			ILogger logger,
			IAirTransportRepository airTransportRepository,
			IApiAirTransportRequestModelValidator airTransportModelValidator,
			IBOLAirTransportMapper bolAirTransportMapper,
			IDALAirTransportMapper dalAirTransportMapper)
			: base()
		{
			this.AirTransportRepository = airTransportRepository;
			this.AirTransportModelValidator = airTransportModelValidator;
			this.BolAirTransportMapper = bolAirTransportMapper;
			this.DalAirTransportMapper = dalAirTransportMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAirTransportResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AirTransportRepository.All(limit, offset);

			return this.BolAirTransportMapper.MapBOToModel(this.DalAirTransportMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAirTransportResponseModel> Get(int airlineId)
		{
			var record = await this.AirTransportRepository.Get(airlineId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAirTransportMapper.MapBOToModel(this.DalAirTransportMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAirTransportResponseModel>> Create(
			ApiAirTransportRequestModel model)
		{
			CreateResponse<ApiAirTransportResponseModel> response = new CreateResponse<ApiAirTransportResponseModel>(await this.AirTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolAirTransportMapper.MapModelToBO(default(int), model);
				var record = await this.AirTransportRepository.Create(this.DalAirTransportMapper.MapBOToEF(bo));

				response.SetRecord(this.BolAirTransportMapper.MapBOToModel(this.DalAirTransportMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAirTransportResponseModel>> Update(
			int airlineId,
			ApiAirTransportRequestModel model)
		{
			var validationResult = await this.AirTransportModelValidator.ValidateUpdateAsync(airlineId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAirTransportMapper.MapModelToBO(airlineId, model);
				await this.AirTransportRepository.Update(this.DalAirTransportMapper.MapBOToEF(bo));

				var record = await this.AirTransportRepository.Get(airlineId);

				return new UpdateResponse<ApiAirTransportResponseModel>(this.BolAirTransportMapper.MapBOToModel(this.DalAirTransportMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiAirTransportResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int airlineId)
		{
			ActionResponse response = new ActionResponse(await this.AirTransportModelValidator.ValidateDeleteAsync(airlineId));
			if (response.Success)
			{
				await this.AirTransportRepository.Delete(airlineId);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>40abd29d3c79701ddf4b957722943f51</Hash>
</Codenesium>*/