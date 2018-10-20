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
	public abstract class AbstractHandlerService : AbstractService
	{
		protected IHandlerRepository HandlerRepository { get; private set; }

		protected IApiHandlerRequestModelValidator HandlerModelValidator { get; private set; }

		protected IBOLHandlerMapper BolHandlerMapper { get; private set; }

		protected IDALHandlerMapper DalHandlerMapper { get; private set; }

		protected IBOLAirTransportMapper BolAirTransportMapper { get; private set; }

		protected IDALAirTransportMapper DalAirTransportMapper { get; private set; }

		private ILogger logger;

		public AbstractHandlerService(
			ILogger logger,
			IHandlerRepository handlerRepository,
			IApiHandlerRequestModelValidator handlerModelValidator,
			IBOLHandlerMapper bolHandlerMapper,
			IDALHandlerMapper dalHandlerMapper,
			IBOLAirTransportMapper bolAirTransportMapper,
			IDALAirTransportMapper dalAirTransportMapper)
			: base()
		{
			this.HandlerRepository = handlerRepository;
			this.HandlerModelValidator = handlerModelValidator;
			this.BolHandlerMapper = bolHandlerMapper;
			this.DalHandlerMapper = dalHandlerMapper;
			this.BolAirTransportMapper = bolAirTransportMapper;
			this.DalAirTransportMapper = dalAirTransportMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiHandlerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.HandlerRepository.All(limit, offset);

			return this.BolHandlerMapper.MapBOToModel(this.DalHandlerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiHandlerResponseModel> Get(int id)
		{
			var record = await this.HandlerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolHandlerMapper.MapBOToModel(this.DalHandlerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiHandlerResponseModel>> Create(
			ApiHandlerRequestModel model)
		{
			CreateResponse<ApiHandlerResponseModel> response = new CreateResponse<ApiHandlerResponseModel>(await this.HandlerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolHandlerMapper.MapModelToBO(default(int), model);
				var record = await this.HandlerRepository.Create(this.DalHandlerMapper.MapBOToEF(bo));

				response.SetRecord(this.BolHandlerMapper.MapBOToModel(this.DalHandlerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiHandlerResponseModel>> Update(
			int id,
			ApiHandlerRequestModel model)
		{
			var validationResult = await this.HandlerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolHandlerMapper.MapModelToBO(id, model);
				await this.HandlerRepository.Update(this.DalHandlerMapper.MapBOToEF(bo));

				var record = await this.HandlerRepository.Get(id);

				return new UpdateResponse<ApiHandlerResponseModel>(this.BolHandlerMapper.MapBOToModel(this.DalHandlerMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiHandlerResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.HandlerModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.HandlerRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiAirTransportResponseModel>> AirTransportsByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			List<AirTransport> records = await this.HandlerRepository.AirTransportsByHandlerId(handlerId, limit, offset);

			return this.BolAirTransportMapper.MapBOToModel(this.DalAirTransportMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiHandlerResponseModel>> ByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			List<Handler> records = await this.HandlerRepository.ByHandlerId(handlerId, limit, offset);

			return this.BolHandlerMapper.MapBOToModel(this.DalHandlerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e4d95ed3dda122d2fe2c158f4bb08eb7</Hash>
</Codenesium>*/