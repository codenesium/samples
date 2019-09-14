using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class CallPersonService : AbstractService, ICallPersonService
	{
		private MediatR.IMediator mediator;

		protected ICallPersonRepository CallPersonRepository { get; private set; }

		protected IApiCallPersonServerRequestModelValidator CallPersonModelValidator { get; private set; }

		protected IDALCallPersonMapper DalCallPersonMapper { get; private set; }

		private ILogger logger;

		public CallPersonService(
			ILogger<ICallPersonService> logger,
			MediatR.IMediator mediator,
			ICallPersonRepository callPersonRepository,
			IApiCallPersonServerRequestModelValidator callPersonModelValidator,
			IDALCallPersonMapper dalCallPersonMapper)
			: base()
		{
			this.CallPersonRepository = callPersonRepository;
			this.CallPersonModelValidator = callPersonModelValidator;
			this.DalCallPersonMapper = dalCallPersonMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCallPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<CallPerson> records = await this.CallPersonRepository.All(limit, offset, query);

			return this.DalCallPersonMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCallPersonServerResponseModel> Get(int id)
		{
			CallPerson record = await this.CallPersonRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCallPersonMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCallPersonServerResponseModel>> Create(
			ApiCallPersonServerRequestModel model)
		{
			CreateResponse<ApiCallPersonServerResponseModel> response = ValidationResponseFactory<ApiCallPersonServerResponseModel>.CreateResponse(await this.CallPersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				CallPerson record = this.DalCallPersonMapper.MapModelToEntity(default(int), model);
				record = await this.CallPersonRepository.Create(record);

				response.SetRecord(this.DalCallPersonMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CallPersonCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCallPersonServerResponseModel>> Update(
			int id,
			ApiCallPersonServerRequestModel model)
		{
			var validationResult = await this.CallPersonModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				CallPerson record = this.DalCallPersonMapper.MapModelToEntity(id, model);
				await this.CallPersonRepository.Update(record);

				record = await this.CallPersonRepository.Get(id);

				ApiCallPersonServerResponseModel apiModel = this.DalCallPersonMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CallPersonUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCallPersonServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCallPersonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CallPersonModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CallPersonRepository.Delete(id);

				await this.mediator.Publish(new CallPersonDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a37bd5038f836b818a93dd3e054e7fde</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/