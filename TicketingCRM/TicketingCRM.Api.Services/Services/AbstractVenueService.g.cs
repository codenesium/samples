using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractVenueService : AbstractService
	{
		protected IVenueRepository VenueRepository { get; private set; }

		protected IApiVenueServerRequestModelValidator VenueModelValidator { get; private set; }

		protected IBOLVenueMapper BolVenueMapper { get; private set; }

		protected IDALVenueMapper DalVenueMapper { get; private set; }

		private ILogger logger;

		public AbstractVenueService(
			ILogger logger,
			IVenueRepository venueRepository,
			IApiVenueServerRequestModelValidator venueModelValidator,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base()
		{
			this.VenueRepository = venueRepository;
			this.VenueModelValidator = venueModelValidator;
			this.BolVenueMapper = bolVenueMapper;
			this.DalVenueMapper = dalVenueMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVenueServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VenueRepository.All(limit, offset);

			return this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVenueServerResponseModel> Get(int id)
		{
			var record = await this.VenueRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVenueServerResponseModel>> Create(
			ApiVenueServerRequestModel model)
		{
			CreateResponse<ApiVenueServerResponseModel> response = ValidationResponseFactory<ApiVenueServerResponseModel>.CreateResponse(await this.VenueModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolVenueMapper.MapModelToBO(default(int), model);
				var record = await this.VenueRepository.Create(this.DalVenueMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVenueServerResponseModel>> Update(
			int id,
			ApiVenueServerRequestModel model)
		{
			var validationResult = await this.VenueModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVenueMapper.MapModelToBO(id, model);
				await this.VenueRepository.Update(this.DalVenueMapper.MapBOToEF(bo));

				var record = await this.VenueRepository.Get(id);

				return ValidationResponseFactory<ApiVenueServerResponseModel>.UpdateResponse(this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiVenueServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VenueModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.VenueRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiVenueServerResponseModel>> ByAdminId(int adminId, int limit = 0, int offset = int.MaxValue)
		{
			List<Venue> records = await this.VenueRepository.ByAdminId(adminId, limit, offset);

			return this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiVenueServerResponseModel>> ByProvinceId(int provinceId, int limit = 0, int offset = int.MaxValue)
		{
			List<Venue> records = await this.VenueRepository.ByProvinceId(provinceId, limit, offset);

			return this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>d6f0201aa9df4d604c0bd01cc879bb55</Hash>
</Codenesium>*/