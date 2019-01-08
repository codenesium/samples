using MediatR;
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
		private IMediator mediator;

		protected IFamilyRepository FamilyRepository { get; private set; }

		protected IApiFamilyServerRequestModelValidator FamilyModelValidator { get; private set; }

		protected IBOLFamilyMapper BolFamilyMapper { get; private set; }

		protected IDALFamilyMapper DalFamilyMapper { get; private set; }

		protected IBOLStudentMapper BolStudentMapper { get; private set; }

		protected IDALStudentMapper DalStudentMapper { get; private set; }

		private ILogger logger;

		public AbstractFamilyService(
			ILogger logger,
			IMediator mediator,
			IFamilyRepository familyRepository,
			IApiFamilyServerRequestModelValidator familyModelValidator,
			IBOLFamilyMapper bolFamilyMapper,
			IDALFamilyMapper dalFamilyMapper,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper)
			: base()
		{
			this.FamilyRepository = familyRepository;
			this.FamilyModelValidator = familyModelValidator;
			this.BolFamilyMapper = bolFamilyMapper;
			this.DalFamilyMapper = dalFamilyMapper;
			this.BolStudentMapper = bolStudentMapper;
			this.DalStudentMapper = dalStudentMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiFamilyServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.FamilyRepository.All(limit, offset);

			return this.BolFamilyMapper.MapBOToModel(this.DalFamilyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFamilyServerResponseModel> Get(int id)
		{
			var record = await this.FamilyRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolFamilyMapper.MapBOToModel(this.DalFamilyMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiFamilyServerResponseModel>> Create(
			ApiFamilyServerRequestModel model)
		{
			CreateResponse<ApiFamilyServerResponseModel> response = ValidationResponseFactory<ApiFamilyServerResponseModel>.CreateResponse(await this.FamilyModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolFamilyMapper.MapModelToBO(default(int), model);
				var record = await this.FamilyRepository.Create(this.DalFamilyMapper.MapBOToEF(bo));

				var businessObject = this.DalFamilyMapper.MapEFToBO(record);
				response.SetRecord(this.BolFamilyMapper.MapBOToModel(businessObject));
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
				var bo = this.BolFamilyMapper.MapModelToBO(id, model);
				await this.FamilyRepository.Update(this.DalFamilyMapper.MapBOToEF(bo));

				var record = await this.FamilyRepository.Get(id);

				var businessObject = this.DalFamilyMapper.MapEFToBO(record);
				var apiModel = this.BolFamilyMapper.MapBOToModel(businessObject);
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

		public async virtual Task<List<ApiStudentServerResponseModel>> StudentsByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0)
		{
			List<Student> records = await this.FamilyRepository.StudentsByFamilyId(familyId, limit, offset);

			return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>937c6e2620fe2ffff5f376099e262632</Hash>
</Codenesium>*/