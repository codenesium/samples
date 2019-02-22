using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractFamilyService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IFamilyRepository FamilyRepository { get; private set; }

		protected IApiFamilyServerRequestModelValidator FamilyModelValidator { get; private set; }

		protected IDALFamilyMapper DalFamilyMapper { get; private set; }

		private ILogger logger;

		public AbstractFamilyService(
			ILogger logger,
			MediatR.IMediator mediator,
			IFamilyRepository familyRepository,
			IApiFamilyServerRequestModelValidator familyModelValidator,
			IDALFamilyMapper dalFamilyMapper)
			: base()
		{
			this.FamilyRepository = familyRepository;
			this.FamilyModelValidator = familyModelValidator;
			this.DalFamilyMapper = dalFamilyMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiFamilyServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Family> records = await this.FamilyRepository.All(limit, offset, query);

			return this.DalFamilyMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiFamilyServerResponseModel> Get(int id)
		{
			Family record = await this.FamilyRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalFamilyMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiFamilyServerResponseModel>> Create(
			ApiFamilyServerRequestModel model)
		{
			CreateResponse<ApiFamilyServerResponseModel> response = ValidationResponseFactory<ApiFamilyServerResponseModel>.CreateResponse(await this.FamilyModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Family record = this.DalFamilyMapper.MapModelToEntity(default(int), model);
				record = await this.FamilyRepository.Create(record);

				response.SetRecord(this.DalFamilyMapper.MapEntityToModel(record));
				await this.mediator.Publish(new FamilyCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFamilyServerResponseModel>> Update(
			int id,
			ApiFamilyServerRequestModel model)
		{
			var validationResult = await this.FamilyModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Family record = this.DalFamilyMapper.MapModelToEntity(id, model);
				await this.FamilyRepository.Update(record);

				record = await this.FamilyRepository.Get(id);

				ApiFamilyServerResponseModel apiModel = this.DalFamilyMapper.MapEntityToModel(record);
				await this.mediator.Publish(new FamilyUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiFamilyServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiFamilyServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.FamilyModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.FamilyRepository.Delete(id);

				await this.mediator.Publish(new FamilyDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bfb1656a1e8dad986b0acec435584521</Hash>
</Codenesium>*/