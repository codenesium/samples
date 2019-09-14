using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class PersonService : AbstractService, IPersonService
	{
		private MediatR.IMediator mediator;

		protected IPersonRepository PersonRepository { get; private set; }

		protected IApiPersonServerRequestModelValidator PersonModelValidator { get; private set; }

		protected IDALPersonMapper DalPersonMapper { get; private set; }

		protected IDALColumnSameAsFKTableMapper DalColumnSameAsFKTableMapper { get; private set; }

		private ILogger logger;

		public PersonService(
			ILogger<IPersonService> logger,
			MediatR.IMediator mediator,
			IPersonRepository personRepository,
			IApiPersonServerRequestModelValidator personModelValidator,
			IDALPersonMapper dalPersonMapper,
			IDALColumnSameAsFKTableMapper dalColumnSameAsFKTableMapper)
			: base()
		{
			this.PersonRepository = personRepository;
			this.PersonModelValidator = personModelValidator;
			this.DalPersonMapper = dalPersonMapper;
			this.DalColumnSameAsFKTableMapper = dalColumnSameAsFKTableMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Person> records = await this.PersonRepository.All(limit, offset, query);

			return this.DalPersonMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPersonServerResponseModel> Get(int personId)
		{
			Person record = await this.PersonRepository.Get(personId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPersonMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPersonServerResponseModel>> Create(
			ApiPersonServerRequestModel model)
		{
			CreateResponse<ApiPersonServerResponseModel> response = ValidationResponseFactory<ApiPersonServerResponseModel>.CreateResponse(await this.PersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Person record = this.DalPersonMapper.MapModelToEntity(default(int), model);
				record = await this.PersonRepository.Create(record);

				response.SetRecord(this.DalPersonMapper.MapEntityToModel(record));
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
				Person record = this.DalPersonMapper.MapModelToEntity(personId, model);
				await this.PersonRepository.Update(record);

				record = await this.PersonRepository.Get(personId);

				ApiPersonServerResponseModel apiModel = this.DalPersonMapper.MapEntityToModel(record);
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

			return this.DalColumnSameAsFKTableMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiColumnSameAsFKTableServerResponseModel>> ColumnSameAsFKTablesByPersonId(int personId, int limit = int.MaxValue, int offset = 0)
		{
			List<ColumnSameAsFKTable> records = await this.PersonRepository.ColumnSameAsFKTablesByPersonId(personId, limit, offset);

			return this.DalColumnSameAsFKTableMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>2788f135f015f9388074f156973ea4a3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/