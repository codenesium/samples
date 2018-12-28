using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractPersonRefService : AbstractService
	{
		private IMediator mediator;

		protected IPersonRefRepository PersonRefRepository { get; private set; }

		protected IApiPersonRefServerRequestModelValidator PersonRefModelValidator { get; private set; }

		protected IBOLPersonRefMapper BolPersonRefMapper { get; private set; }

		protected IDALPersonRefMapper DalPersonRefMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonRefService(
			ILogger logger,
			IMediator mediator,
			IPersonRefRepository personRefRepository,
			IApiPersonRefServerRequestModelValidator personRefModelValidator,
			IBOLPersonRefMapper bolPersonRefMapper,
			IDALPersonRefMapper dalPersonRefMapper)
			: base()
		{
			this.PersonRefRepository = personRefRepository;
			this.PersonRefModelValidator = personRefModelValidator;
			this.BolPersonRefMapper = bolPersonRefMapper;
			this.DalPersonRefMapper = dalPersonRefMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPersonRefServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PersonRefRepository.All(limit, offset);

			return this.BolPersonRefMapper.MapBOToModel(this.DalPersonRefMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonRefServerResponseModel> Get(int id)
		{
			var record = await this.PersonRefRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPersonRefMapper.MapBOToModel(this.DalPersonRefMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPersonRefServerResponseModel>> Create(
			ApiPersonRefServerRequestModel model)
		{
			CreateResponse<ApiPersonRefServerResponseModel> response = ValidationResponseFactory<ApiPersonRefServerResponseModel>.CreateResponse(await this.PersonRefModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPersonRefMapper.MapModelToBO(default(int), model);
				var record = await this.PersonRefRepository.Create(this.DalPersonRefMapper.MapBOToEF(bo));

				var businessObject = this.DalPersonRefMapper.MapEFToBO(record);
				response.SetRecord(this.BolPersonRefMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new PersonRefCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonRefServerResponseModel>> Update(
			int id,
			ApiPersonRefServerRequestModel model)
		{
			var validationResult = await this.PersonRefModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPersonRefMapper.MapModelToBO(id, model);
				await this.PersonRefRepository.Update(this.DalPersonRefMapper.MapBOToEF(bo));

				var record = await this.PersonRefRepository.Get(id);

				var businessObject = this.DalPersonRefMapper.MapEFToBO(record);
				var apiModel = this.BolPersonRefMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new PersonRefUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPersonRefServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPersonRefServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PersonRefModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PersonRefRepository.Delete(id);

				await this.mediator.Publish(new PersonRefDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4897a5201466ad486b0b42b81cf2e4c5</Hash>
</Codenesium>*/