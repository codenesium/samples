using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractPersonService : AbstractService
	{
		private IMediator mediator;

		protected IPersonRepository PersonRepository { get; private set; }

		protected IApiPersonServerRequestModelValidator PersonModelValidator { get; private set; }

		protected IBOLPersonMapper BolPersonMapper { get; private set; }

		protected IDALPersonMapper DalPersonMapper { get; private set; }

		protected IBOLColumnSameAsFKTableMapper BolColumnSameAsFKTableMapper { get; private set; }

		protected IDALColumnSameAsFKTableMapper DalColumnSameAsFKTableMapper { get; private set; }

		private ILogger logger;

		public AbstractPersonService(
			ILogger logger,
			IMediator mediator,
			IPersonRepository personRepository,
			IApiPersonServerRequestModelValidator personModelValidator,
			IBOLPersonMapper bolPersonMapper,
			IDALPersonMapper dalPersonMapper,
			IBOLColumnSameAsFKTableMapper bolColumnSameAsFKTableMapper,
			IDALColumnSameAsFKTableMapper dalColumnSameAsFKTableMapper)
			: base()
		{
			this.PersonRepository = personRepository;
			this.PersonModelValidator = personModelValidator;
			this.BolPersonMapper = bolPersonMapper;
			this.DalPersonMapper = dalPersonMapper;
			this.BolColumnSameAsFKTableMapper = bolColumnSameAsFKTableMapper;
			this.DalColumnSameAsFKTableMapper = dalColumnSameAsFKTableMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PersonRepository.All(limit, offset);

			return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPersonServerResponseModel> Get(int personId)
		{
			var record = await this.PersonRepository.Get(personId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPersonMapper.MapBOToModel(this.DalPersonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPersonServerResponseModel>> Create(
			ApiPersonServerRequestModel model)
		{
			CreateResponse<ApiPersonServerResponseModel> response = ValidationResponseFactory<ApiPersonServerResponseModel>.CreateResponse(await this.PersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPersonMapper.MapModelToBO(default(int), model);
				var record = await this.PersonRepository.Create(this.DalPersonMapper.MapBOToEF(bo));

				var businessObject = this.DalPersonMapper.MapEFToBO(record);
				response.SetRecord(this.BolPersonMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new PersonCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPersonServerResponseModel>> Update(
			int personId,
			ApiPersonServerRequestModel model)
		{
			var validationResult = await this.PersonModelValidator.ValidateUpdateAsync(personId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPersonMapper.MapModelToBO(personId, model);
				await this.PersonRepository.Update(this.DalPersonMapper.MapBOToEF(bo));

				var record = await this.PersonRepository.Get(personId);

				var businessObject = this.DalPersonMapper.MapEFToBO(record);
				var apiModel = this.BolPersonMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new PersonUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPersonServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPersonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int personId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PersonModelValidator.ValidateDeleteAsync(personId));

			if (response.Success)
			{
				await this.PersonRepository.Delete(personId);

				await this.mediator.Publish(new PersonDeletedNotification(personId));
			}

			return response;
		}

		public async virtual Task<List<ApiColumnSameAsFKTableServerResponseModel>> ColumnSameAsFKTablesByPerson(int person, int limit = int.MaxValue, int offset = 0)
		{
			List<ColumnSameAsFKTable> records = await this.PersonRepository.ColumnSameAsFKTablesByPerson(person, limit, offset);

			return this.BolColumnSameAsFKTableMapper.MapBOToModel(this.DalColumnSameAsFKTableMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiColumnSameAsFKTableServerResponseModel>> ColumnSameAsFKTablesByPersonId(int personId, int limit = int.MaxValue, int offset = 0)
		{
			List<ColumnSameAsFKTable> records = await this.PersonRepository.ColumnSameAsFKTablesByPersonId(personId, limit, offset);

			return this.BolColumnSameAsFKTableMapper.MapBOToModel(this.DalColumnSameAsFKTableMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>0bc0d404d79af37a4e0dde07fffee322</Hash>
</Codenesium>*/