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

		protected IBOLCityMapper BolCityMapper { get; private set; }

		protected IDALCityMapper DalCityMapper { get; private set; }

		protected IBOLEventMapper BolEventMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public AbstractCityService(
			ILogger logger,
			IMediator mediator,
			ICityRepository cityRepository,
			IApiCityServerRequestModelValidator cityModelValidator,
			IBOLCityMapper bolCityMapper,
			IDALCityMapper dalCityMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.CityRepository = cityRepository;
			this.CityModelValidator = cityModelValidator;
			this.BolCityMapper = bolCityMapper;
			this.DalCityMapper = dalCityMapper;
			this.BolEventMapper = bolEventMapper;
			this.DalEventMapper = dalEventMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCityServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CityRepository.All(limit, offset);

			return this.BolCityMapper.MapBOToModel(this.DalCityMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCityServerResponseModel> Get(int id)
		{
			var record = await this.CityRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCityMapper.MapBOToModel(this.DalCityMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCityServerResponseModel>> Create(
			ApiCityServerRequestModel model)
		{
			CreateResponse<ApiCityServerResponseModel> response = ValidationResponseFactory<ApiCityServerResponseModel>.CreateResponse(await this.CityModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCityMapper.MapModelToBO(default(int), model);
				var record = await this.CityRepository.Create(this.DalCityMapper.MapBOToEF(bo));

				var businessObject = this.DalCityMapper.MapEFToBO(record);
				response.SetRecord(this.BolCityMapper.MapBOToModel(businessObject));
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
				var bo = this.BolCityMapper.MapModelToBO(id, model);
				await this.CityRepository.Update(this.DalCityMapper.MapBOToEF(bo));

				var record = await this.CityRepository.Get(id);

				var businessObject = this.DalCityMapper.MapEFToBO(record);
				var apiModel = this.BolCityMapper.MapBOToModel(businessObject);
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

			return this.BolCityMapper.MapBOToModel(this.DalCityMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiEventServerResponseModel>> EventsByCityId(int cityId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.CityRepository.EventsByCityId(cityId, limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e98372bfce822370a6eb852f8ad7644d</Hash>
</Codenesium>*/