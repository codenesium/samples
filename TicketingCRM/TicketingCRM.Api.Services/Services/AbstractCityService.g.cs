using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractCityService : AbstractService
	{
		private IMediator mediator;

		protected ICityRepository CityRepository { get; private set; }

		protected IApiCityServerRequestModelValidator CityModelValidator { get; private set; }

		protected IDALCityMapper DalCityMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public AbstractCityService(
			ILogger logger,
			IMediator mediator,
			ICityRepository cityRepository,
			IApiCityServerRequestModelValidator cityModelValidator,
			IDALCityMapper dalCityMapper,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.CityRepository = cityRepository;
			this.CityModelValidator = cityModelValidator;
			this.DalCityMapper = dalCityMapper;
			this.DalEventMapper = dalEventMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCityServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<City> records = await this.CityRepository.All(limit, offset, query);

			return this.DalCityMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCityServerResponseModel> Get(int id)
		{
			City record = await this.CityRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCityMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCityServerResponseModel>> Create(
			ApiCityServerRequestModel model)
		{
			CreateResponse<ApiCityServerResponseModel> response = ValidationResponseFactory<ApiCityServerResponseModel>.CreateResponse(await this.CityModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				City record = this.DalCityMapper.MapModelToEntity(default(int), model);
				record = await this.CityRepository.Create(record);

				response.SetRecord(this.DalCityMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CityCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCityServerResponseModel>> Update(
			int id,
			ApiCityServerRequestModel model)
		{
			var validationResult = await this.CityModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				City record = this.DalCityMapper.MapModelToEntity(id, model);
				await this.CityRepository.Update(record);

				record = await this.CityRepository.Get(id);

				ApiCityServerResponseModel apiModel = this.DalCityMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CityUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCityServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCityServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CityModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CityRepository.Delete(id);

				await this.mediator.Publish(new CityDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCityServerResponseModel>> ByProvinceId(int provinceId, int limit = 0, int offset = int.MaxValue)
		{
			List<City> records = await this.CityRepository.ByProvinceId(provinceId, limit, offset);

			return this.DalCityMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiEventServerResponseModel>> EventsByCityId(int cityId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.CityRepository.EventsByCityId(cityId, limit, offset);

			return this.DalEventMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>85a86dae9b092e99ce9b953fb609af36</Hash>
</Codenesium>*/