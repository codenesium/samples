using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractFamilyService : AbstractService
	{
		protected IFamilyRepository FamilyRepository { get; private set; }

		protected IApiFamilyRequestModelValidator FamilyModelValidator { get; private set; }

		protected IBOLFamilyMapper BolFamilyMapper { get; private set; }

		protected IDALFamilyMapper DalFamilyMapper { get; private set; }

		protected IBOLStudentMapper BolStudentMapper { get; private set; }

		protected IDALStudentMapper DalStudentMapper { get; private set; }

		private ILogger logger;

		public AbstractFamilyService(
			ILogger logger,
			IFamilyRepository familyRepository,
			IApiFamilyRequestModelValidator familyModelValidator,
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
		}

		public virtual async Task<List<ApiFamilyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.FamilyRepository.All(limit, offset);

			return this.BolFamilyMapper.MapBOToModel(this.DalFamilyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFamilyResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiFamilyResponseModel>> Create(
			ApiFamilyRequestModel model)
		{
			CreateResponse<ApiFamilyResponseModel> response = new CreateResponse<ApiFamilyResponseModel>(await this.FamilyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolFamilyMapper.MapModelToBO(default(int), model);
				var record = await this.FamilyRepository.Create(this.DalFamilyMapper.MapBOToEF(bo));

				response.SetRecord(this.BolFamilyMapper.MapBOToModel(this.DalFamilyMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFamilyResponseModel>> Update(
			int id,
			ApiFamilyRequestModel model)
		{
			var validationResult = await this.FamilyModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolFamilyMapper.MapModelToBO(id, model);
				await this.FamilyRepository.Update(this.DalFamilyMapper.MapBOToEF(bo));

				var record = await this.FamilyRepository.Get(id);

				return new UpdateResponse<ApiFamilyResponseModel>(this.BolFamilyMapper.MapBOToModel(this.DalFamilyMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiFamilyResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.FamilyModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.FamilyRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiStudentResponseModel>> Students(int familyId, int limit = int.MaxValue, int offset = 0)
		{
			List<Student> records = await this.FamilyRepository.Students(familyId, limit, offset);

			return this.BolStudentMapper.MapBOToModel(this.DalStudentMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e8f76a3579c644e2646d67bbc42bc01d</Hash>
</Codenesium>*/