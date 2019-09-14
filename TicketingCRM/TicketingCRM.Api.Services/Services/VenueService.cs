using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class VenueService : AbstractService, IVenueService
	{
		private MediatR.IMediator mediator;

		protected IVenueRepository VenueRepository { get; private set; }

		protected IApiVenueServerRequestModelValidator VenueModelValidator { get; private set; }

		protected IDALVenueMapper DalVenueMapper { get; private set; }

		private ILogger logger;

		public VenueService(
			ILogger<IVenueService> logger,
			MediatR.IMediator mediator,
			IVenueRepository venueRepository,
			IApiVenueServerRequestModelValidator venueModelValidator,
			IDALVenueMapper dalVenueMapper)
			: base()
		{
			this.VenueRepository = venueRepository;
			this.VenueModelValidator = venueModelValidator;
			this.DalVenueMapper = dalVenueMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVenueServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Venue> records = await this.VenueRepository.All(limit, offset, query);

			return this.DalVenueMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVenueServerResponseModel> Get(int id)
		{
			Venue record = await this.VenueRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVenueMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVenueServerResponseModel>> Create(
			ApiVenueServerRequestModel model)
		{
			CreateResponse<ApiVenueServerResponseModel> response = ValidationResponseFactory<ApiVenueServerResponseModel>.CreateResponse(await this.VenueModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Venue record = this.DalVenueMapper.MapModelToEntity(default(int), model);
				record = await this.VenueRepository.Create(record);

				response.SetRecord(this.DalVenueMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VenueCreatedNotification(response.Record));
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
				Venue record = this.DalVenueMapper.MapModelToEntity(id, model);
				await this.VenueRepository.Update(record);

				record = await this.VenueRepository.Get(id);

				ApiVenueServerResponseModel apiModel = this.DalVenueMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VenueUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVenueServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new VenueDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiVenueServerResponseModel>> ByAdminId(int adminId, int limit = 0, int offset = int.MaxValue)
		{
			List<Venue> records = await this.VenueRepository.ByAdminId(adminId, limit, offset);

			return this.DalVenueMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVenueServerResponseModel>> ByProvinceId(int provinceId, int limit = 0, int offset = int.MaxValue)
		{
			List<Venue> records = await this.VenueRepository.ByProvinceId(provinceId, limit, offset);

			return this.DalVenueMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>016ca2fce0b66e8d4e9f0c7fe2e3351e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/