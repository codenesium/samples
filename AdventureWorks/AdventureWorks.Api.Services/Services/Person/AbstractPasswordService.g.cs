using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPasswordService : AbstractService
	{
		private IMediator mediator;

		protected IPasswordRepository PasswordRepository { get; private set; }

		protected IApiPasswordServerRequestModelValidator PasswordModelValidator { get; private set; }

		protected IBOLPasswordMapper BolPasswordMapper { get; private set; }

		protected IDALPasswordMapper DalPasswordMapper { get; private set; }

		private ILogger logger;

		public AbstractPasswordService(
			ILogger logger,
			IMediator mediator,
			IPasswordRepository passwordRepository,
			IApiPasswordServerRequestModelValidator passwordModelValidator,
			IBOLPasswordMapper bolPasswordMapper,
			IDALPasswordMapper dalPasswordMapper)
			: base()
		{
			this.PasswordRepository = passwordRepository;
			this.PasswordModelValidator = passwordModelValidator;
			this.BolPasswordMapper = bolPasswordMapper;
			this.DalPasswordMapper = dalPasswordMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPasswordServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PasswordRepository.All(limit, offset);

			return this.BolPasswordMapper.MapBOToModel(this.DalPasswordMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPasswordServerResponseModel> Get(int businessEntityID)
		{
			var record = await this.PasswordRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPasswordMapper.MapBOToModel(this.DalPasswordMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPasswordServerResponseModel>> Create(
			ApiPasswordServerRequestModel model)
		{
			CreateResponse<ApiPasswordServerResponseModel> response = ValidationResponseFactory<ApiPasswordServerResponseModel>.CreateResponse(await this.PasswordModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPasswordMapper.MapModelToBO(default(int), model);
				var record = await this.PasswordRepository.Create(this.DalPasswordMapper.MapBOToEF(bo));

				var businessObject = this.DalPasswordMapper.MapEFToBO(record);
				response.SetRecord(this.BolPasswordMapper.MapBOToModel(businessObject));
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
				var bo = this.BolPasswordMapper.MapModelToBO(businessEntityID, model);
				await this.PasswordRepository.Update(this.DalPasswordMapper.MapBOToEF(bo));

				var record = await this.PasswordRepository.Get(businessEntityID);

				var businessObject = this.DalPasswordMapper.MapEFToBO(record);
				var apiModel = this.BolPasswordMapper.MapBOToModel(businessObject);
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
    <Hash>58ed33e3caade320e05e2de0e9a10555</Hash>
</Codenesium>*/