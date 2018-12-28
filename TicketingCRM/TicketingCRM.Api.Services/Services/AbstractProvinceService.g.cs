using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractProvinceService : AbstractService
	{
		private IMediator mediator;

		protected IProvinceRepository ProvinceRepository { get; private set; }

		protected IApiProvinceServerRequestModelValidator ProvinceModelValidator { get; private set; }

		protected IBOLProvinceMapper BolProvinceMapper { get; private set; }

		protected IDALProvinceMapper DalProvinceMapper { get; private set; }

		protected IBOLCityMapper BolCityMapper { get; private set; }

		protected IDALCityMapper DalCityMapper { get; private set; }

		protected IBOLVenueMapper BolVenueMapper { get; private set; }

		protected IDALVenueMapper DalVenueMapper { get; private set; }

		private ILogger logger;

		public AbstractProvinceService(
			ILogger logger,
			IMediator mediator,
			IProvinceRepository provinceRepository,
			IApiProvinceServerRequestModelValidator provinceModelValidator,
			IBOLProvinceMapper bolProvinceMapper,
			IDALProvinceMapper dalProvinceMapper,
			IBOLCityMapper bolCityMapper,
			IDALCityMapper dalCityMapper,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base()
		{
			this.ProvinceRepository = provinceRepository;
			this.ProvinceModelValidator = provinceModelValidator;
			this.BolProvinceMapper = bolProvinceMapper;
			this.DalProvinceMapper = dalProvinceMapper;
			this.BolCityMapper = bolCityMapper;
			this.DalCityMapper = dalCityMapper;
			this.BolVenueMapper = bolVenueMapper;
			this.DalVenueMapper = dalVenueMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProvinceServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProvinceRepository.All(limit, offset);

			return this.BolProvinceMapper.MapBOToModel(this.DalProvinceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProvinceServerResponseModel> Get(int id)
		{
			var record = await this.ProvinceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProvinceMapper.MapBOToModel(this.DalProvinceMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProvinceServerResponseModel>> Create(
			ApiProvinceServerRequestModel model)
		{
			CreateResponse<ApiProvinceServerResponseModel> response = ValidationResponseFactory<ApiProvinceServerResponseModel>.CreateResponse(await this.ProvinceModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolProvinceMapper.MapModelToBO(default(int), model);
				var record = await this.ProvinceRepository.Create(this.DalProvinceMapper.MapBOToEF(bo));

				var businessObject = this.DalProvinceMapper.MapEFToBO(record);
				response.SetRecord(this.BolProvinceMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new ProvinceCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProvinceServerResponseModel>> Update(
			int id,
			ApiProvinceServerRequestModel model)
		{
			var validationResult = await this.ProvinceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProvinceMapper.MapModelToBO(id, model);
				await this.ProvinceRepository.Update(this.DalProvinceMapper.MapBOToEF(bo));

				var record = await this.ProvinceRepository.Get(id);

				var businessObject = this.DalProvinceMapper.MapEFToBO(record);
				var apiModel = this.BolProvinceMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new ProvinceUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiProvinceServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiProvinceServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProvinceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.ProvinceRepository.Delete(id);

				await this.mediator.Publish(new ProvinceDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiProvinceServerResponseModel>> ByCountryId(int countryId, int limit = 0, int offset = int.MaxValue)
		{
			List<Province> records = await this.ProvinceRepository.ByCountryId(countryId, limit, offset);

			return this.BolProvinceMapper.MapBOToModel(this.DalProvinceMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiCityServerResponseModel>> CitiesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			List<City> records = await this.ProvinceRepository.CitiesByProvinceId(provinceId, limit, offset);

			return this.BolCityMapper.MapBOToModel(this.DalCityMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiVenueServerResponseModel>> VenuesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			List<Venue> records = await this.ProvinceRepository.VenuesByProvinceId(provinceId, limit, offset);

			return this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>4869e944c9c74fe13a516ffd928d273f</Hash>
</Codenesium>*/