using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPasswordService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPasswordRepository PasswordRepository { get; private set; }

		protected IApiPasswordServerRequestModelValidator PasswordModelValidator { get; private set; }

		protected IDALPasswordMapper DalPasswordMapper { get; private set; }

		private ILogger logger;

		public AbstractPasswordService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPasswordRepository passwordRepository,
			IApiPasswordServerRequestModelValidator passwordModelValidator,
			IDALPasswordMapper dalPasswordMapper)
			: base()
		{
			this.PasswordRepository = passwordRepository;
			this.PasswordModelValidator = passwordModelValidator;
			this.DalPasswordMapper = dalPasswordMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPasswordServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Password> records = await this.PasswordRepository.All(limit, offset, query);

			return this.DalPasswordMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPasswordServerResponseModel> Get(int businessEntityID)
		{
			Password record = await this.PasswordRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPasswordMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPasswordServerResponseModel>> Create(
			ApiPasswordServerRequestModel model)
		{
			CreateResponse<ApiPasswordServerResponseModel> response = ValidationResponseFactory<ApiPasswordServerResponseModel>.CreateResponse(await this.PasswordModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Password record = this.DalPasswordMapper.MapModelToEntity(default(int), model);
				record = await this.PasswordRepository.Create(record);

				response.SetRecord(this.DalPasswordMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PasswordCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPasswordServerResponseModel>> Update(
			int businessEntityID,
			ApiPasswordServerRequestModel model)
		{
			var validationResult = await this.PasswordModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				Password record = this.DalPasswordMapper.MapModelToEntity(businessEntityID, model);
				await this.PasswordRepository.Update(record);

				record = await this.PasswordRepository.Get(businessEntityID);

				ApiPasswordServerResponseModel apiModel = this.DalPasswordMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PasswordUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPasswordServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPasswordServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PasswordModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.PasswordRepository.Delete(businessEntityID);

				await this.mediator.Publish(new PasswordDeletedNotification(businessEntityID));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>eddc8ec5422666bad1a800736bbdd340</Hash>
</Codenesium>*/