using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractIncludedColumnTestService : AbstractService
	{
		private IMediator mediator;

		protected IIncludedColumnTestRepository IncludedColumnTestRepository { get; private set; }

		protected IApiIncludedColumnTestServerRequestModelValidator IncludedColumnTestModelValidator { get; private set; }

		protected IBOLIncludedColumnTestMapper BolIncludedColumnTestMapper { get; private set; }

		protected IDALIncludedColumnTestMapper DalIncludedColumnTestMapper { get; private set; }

		private ILogger logger;

		public AbstractIncludedColumnTestService(
			ILogger logger,
			IMediator mediator,
			IIncludedColumnTestRepository includedColumnTestRepository,
			IApiIncludedColumnTestServerRequestModelValidator includedColumnTestModelValidator,
			IBOLIncludedColumnTestMapper bolIncludedColumnTestMapper,
			IDALIncludedColumnTestMapper dalIncludedColumnTestMapper)
			: base()
		{
			this.IncludedColumnTestRepository = includedColumnTestRepository;
			this.IncludedColumnTestModelValidator = includedColumnTestModelValidator;
			this.BolIncludedColumnTestMapper = bolIncludedColumnTestMapper;
			this.DalIncludedColumnTestMapper = dalIncludedColumnTestMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiIncludedColumnTestServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.IncludedColumnTestRepository.All(limit, offset);

			return this.BolIncludedColumnTestMapper.MapBOToModel(this.DalIncludedColumnTestMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiIncludedColumnTestServerResponseModel> Get(int id)
		{
			var record = await this.IncludedColumnTestRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolIncludedColumnTestMapper.MapBOToModel(this.DalIncludedColumnTestMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiIncludedColumnTestServerResponseModel>> Create(
			ApiIncludedColumnTestServerRequestModel model)
		{
			CreateResponse<ApiIncludedColumnTestServerResponseModel> response = ValidationResponseFactory<ApiIncludedColumnTestServerResponseModel>.CreateResponse(await this.IncludedColumnTestModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolIncludedColumnTestMapper.MapModelToBO(default(int), model);
				var record = await this.IncludedColumnTestRepository.Create(this.DalIncludedColumnTestMapper.MapBOToEF(bo));

				var businessObject = this.DalIncludedColumnTestMapper.MapEFToBO(record);
				response.SetRecord(this.BolIncludedColumnTestMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new IncludedColumnTestCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiIncludedColumnTestServerResponseModel>> Update(
			int id,
			ApiIncludedColumnTestServerRequestModel model)
		{
			var validationResult = await this.IncludedColumnTestModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolIncludedColumnTestMapper.MapModelToBO(id, model);
				await this.IncludedColumnTestRepository.Update(this.DalIncludedColumnTestMapper.MapBOToEF(bo));

				var record = await this.IncludedColumnTestRepository.Get(id);

				var businessObject = this.DalIncludedColumnTestMapper.MapEFToBO(record);
				var apiModel = this.BolIncludedColumnTestMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new IncludedColumnTestUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiIncludedColumnTestServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiIncludedColumnTestServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.IncludedColumnTestModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.IncludedColumnTestRepository.Delete(id);

				await this.mediator.Publish(new IncludedColumnTestDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>be691fecdea8900e1a143a462927d99b</Hash>
</Codenesium>*/