using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractVPersonService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IVPersonRepository VPersonRepository { get; private set; }

		protected IApiVPersonServerRequestModelValidator VPersonModelValidator { get; private set; }

		protected IDALVPersonMapper DalVPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractVPersonService(
			ILogger logger,
			MediatR.IMediator mediator,
			IVPersonRepository vPersonRepository,
			IApiVPersonServerRequestModelValidator vPersonModelValidator,
			IDALVPersonMapper dalVPersonMapper)
			: base()
		{
			this.VPersonRepository = vPersonRepository;
			this.VPersonModelValidator = vPersonModelValidator;
			this.DalVPersonMapper = dalVPersonMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<VPerson> records = await this.VPersonRepository.All(limit, offset, query);

			return this.DalVPersonMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVPersonServerResponseModel> Get(int personId)
		{
			VPerson record = await this.VPersonRepository.Get(personId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVPersonMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVPersonServerResponseModel>> Create(
			ApiVPersonServerRequestModel model)
		{
			CreateResponse<ApiVPersonServerResponseModel> response = ValidationResponseFactory<ApiVPersonServerResponseModel>.CreateResponse(await this.VPersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				VPerson record = this.DalVPersonMapper.MapModelToEntity(default(int), model);
				record = await this.VPersonRepository.Create(record);

				response.SetRecord(this.DalVPersonMapper.MapEntityToModel(record));
				await this.mediator.Publish(new VPersonCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVPersonServerResponseModel>> Update(
			int personId,
			ApiVPersonServerRequestModel model)
		{
			var validationResult = await this.VPersonModelValidator.ValidateUpdateAsync(personId, model);

			if (validationResult.IsValid)
			{
				VPerson record = this.DalVPersonMapper.MapModelToEntity(personId, model);
				await this.VPersonRepository.Update(record);

				record = await this.VPersonRepository.Get(personId);

				ApiVPersonServerResponseModel apiModel = this.DalVPersonMapper.MapEntityToModel(record);
				await this.mediator.Publish(new VPersonUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVPersonServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVPersonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int personId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VPersonModelValidator.ValidateDeleteAsync(personId));

			if (response.Success)
			{
				await this.VPersonRepository.Delete(personId);

				await this.mediator.Publish(new VPersonDeletedNotification(personId));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>445c3260fd892c5d18200cd59280d2d5</Hash>
</Codenesium>*/