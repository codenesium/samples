using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractProvinceService : AbstractService
	{
		protected IProvinceRepository ProvinceRepository { get; private set; }

		protected IApiProvinceRequestModelValidator ProvinceModelValidator { get; private set; }

		protected IBOLProvinceMapper BolProvinceMapper { get; private set; }

		protected IDALProvinceMapper DalProvinceMapper { get; private set; }

		protected IBOLCityMapper BolCityMapper { get; private set; }

		protected IDALCityMapper DalCityMapper { get; private set; }
		protected IBOLVenueMapper BolVenueMapper { get; private set; }

		protected IDALVenueMapper DalVenueMapper { get; private set; }

		private ILogger logger;

		public AbstractProvinceService(
			ILogger logger,
			IProvinceRepository provinceRepository,
			IApiProvinceRequestModelValidator provinceModelValidator,
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
		}

		public virtual async Task<List<ApiProvinceResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProvinceRepository.All(limit, offset);

			return this.BolProvinceMapper.MapBOToModel(this.DalProvinceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProvinceResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiProvinceResponseModel>> Create(
			ApiProvinceRequestModel model)
		{
			CreateResponse<ApiProvinceResponseModel> response = new CreateResponse<ApiProvinceResponseModel>(await this.ProvinceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProvinceMapper.MapModelToBO(default(int), model);
				var record = await this.ProvinceRepository.Create(this.DalProvinceMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProvinceMapper.MapBOToModel(this.DalProvinceMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProvinceResponseModel>> Update(
			int id,
			ApiProvinceRequestModel model)
		{
			var validationResult = await this.ProvinceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProvinceMapper.MapModelToBO(id, model);
				await this.ProvinceRepository.Update(this.DalProvinceMapper.MapBOToEF(bo));

				var record = await this.ProvinceRepository.Get(id);

				return new UpdateResponse<ApiProvinceResponseModel>(this.BolProvinceMapper.MapBOToModel(this.DalProvinceMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProvinceResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.ProvinceModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ProvinceRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiProvinceResponseModel>> ByCountryId(int countryId)
		{
			List<Province> records = await this.ProvinceRepository.ByCountryId(countryId);

			return this.BolProvinceMapper.MapBOToModel(this.DalProvinceMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiCityResponseModel>> Cities(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			List<City> records = await this.ProvinceRepository.Cities(provinceId, limit, offset);

			return this.BolCityMapper.MapBOToModel(this.DalCityMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiVenueResponseModel>> Venues(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			List<Venue> records = await this.ProvinceRepository.Venues(provinceId, limit, offset);

			return this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b1e82c9c0f301939190155eea2160488</Hash>
</Codenesium>*/