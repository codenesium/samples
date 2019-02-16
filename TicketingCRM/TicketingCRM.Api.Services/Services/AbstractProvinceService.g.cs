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

		protected IDALProvinceMapper DalProvinceMapper { get; private set; }

		protected IDALCityMapper DalCityMapper { get; private set; }

		protected IDALVenueMapper DalVenueMapper { get; private set; }

		private ILogger logger;

		public AbstractProvinceService(
			ILogger logger,
			IMediator mediator,
			IProvinceRepository provinceRepository,
			IApiProvinceServerRequestModelValidator provinceModelValidator,
			IDALProvinceMapper dalProvinceMapper,
			IDALCityMapper dalCityMapper,
			IDALVenueMapper dalVenueMapper)
			: base()
		{
			this.ProvinceRepository = provinceRepository;
			this.ProvinceModelValidator = provinceModelValidator;
			this.DalProvinceMapper = dalProvinceMapper;
			this.DalCityMapper = dalCityMapper;
			this.DalVenueMapper = dalVenueMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProvinceServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Province> records = await this.ProvinceRepository.All(limit, offset, query);

			return this.DalProvinceMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiProvinceServerResponseModel> Get(int id)
		{
			Province record = await this.ProvinceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProvinceMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProvinceServerResponseModel>> Create(
			ApiProvinceServerRequestModel model)
		{
			CreateResponse<ApiProvinceServerResponseModel> response = ValidationResponseFactory<ApiProvinceServerResponseModel>.CreateResponse(await this.ProvinceModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Province record = this.DalProvinceMapper.MapModelToEntity(default(int), model);
				record = await this.ProvinceRepository.Create(record);

				response.SetRecord(this.DalProvinceMapper.MapEntityToModel(record));
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
				Province record = this.DalProvinceMapper.MapModelToEntity(id, model);
				await this.ProvinceRepository.Update(record);

				record = await this.ProvinceRepository.Get(id);

				ApiProvinceServerResponseModel apiModel = this.DalProvinceMapper.MapEntityToModel(record);
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

			return this.DalProvinceMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiCityServerResponseModel>> CitiesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			List<City> records = await this.ProvinceRepository.CitiesByProvinceId(provinceId, limit, offset);

			return this.DalCityMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVenueServerResponseModel>> VenuesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			List<Venue> records = await this.ProvinceRepository.VenuesByProvinceId(provinceId, limit, offset);

			return this.DalVenueMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>10474d5d726fe59c2b37895f43aa03f0</Hash>
</Codenesium>*/