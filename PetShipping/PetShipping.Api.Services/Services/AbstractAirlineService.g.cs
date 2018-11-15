using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractAirlineService : AbstractService
	{
		protected IAirlineRepository AirlineRepository { get; private set; }

		protected IApiAirlineServerRequestModelValidator AirlineModelValidator { get; private set; }

		protected IBOLAirlineMapper BolAirlineMapper { get; private set; }

		protected IDALAirlineMapper DalAirlineMapper { get; private set; }

		private ILogger logger;

		public AbstractAirlineService(
			ILogger logger,
			IAirlineRepository airlineRepository,
			IApiAirlineServerRequestModelValidator airlineModelValidator,
			IBOLAirlineMapper bolAirlineMapper,
			IDALAirlineMapper dalAirlineMapper)
			: base()
		{
			this.AirlineRepository = airlineRepository;
			this.AirlineModelValidator = airlineModelValidator;
			this.BolAirlineMapper = bolAirlineMapper;
			this.DalAirlineMapper = dalAirlineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAirlineServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AirlineRepository.All(limit, offset);

			return this.BolAirlineMapper.MapBOToModel(this.DalAirlineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAirlineServerResponseModel> Get(int id)
		{
			var record = await this.AirlineRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAirlineMapper.MapBOToModel(this.DalAirlineMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAirlineServerResponseModel>> Create(
			ApiAirlineServerRequestModel model)
		{
			CreateResponse<ApiAirlineServerResponseModel> response = ValidationResponseFactory<ApiAirlineServerResponseModel>.CreateResponse(await this.AirlineModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolAirlineMapper.MapModelToBO(default(int), model);
				var record = await this.AirlineRepository.Create(this.DalAirlineMapper.MapBOToEF(bo));

				response.SetRecord(this.BolAirlineMapper.MapBOToModel(this.DalAirlineMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAirlineServerResponseModel>> Update(
			int id,
			ApiAirlineServerRequestModel model)
		{
			var validationResult = await this.AirlineModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAirlineMapper.MapModelToBO(id, model);
				await this.AirlineRepository.Update(this.DalAirlineMapper.MapBOToEF(bo));

				var record = await this.AirlineRepository.Get(id);

				return ValidationResponseFactory<ApiAirlineServerResponseModel>.UpdateResponse(this.BolAirlineMapper.MapBOToModel(this.DalAirlineMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiAirlineServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AirlineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.AirlineRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>447152d25d1aa9f585afa3b06891261d</Hash>
</Codenesium>*/