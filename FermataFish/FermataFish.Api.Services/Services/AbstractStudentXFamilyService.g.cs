using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractStudentXFamilyService : AbstractService
	{
		protected IStudentXFamilyRepository StudentXFamilyRepository { get; private set; }

		protected IApiStudentXFamilyRequestModelValidator StudentXFamilyModelValidator { get; private set; }

		protected IBOLStudentXFamilyMapper BolStudentXFamilyMapper { get; private set; }

		protected IDALStudentXFamilyMapper DalStudentXFamilyMapper { get; private set; }

		private ILogger logger;

		public AbstractStudentXFamilyService(
			ILogger logger,
			IStudentXFamilyRepository studentXFamilyRepository,
			IApiStudentXFamilyRequestModelValidator studentXFamilyModelValidator,
			IBOLStudentXFamilyMapper bolStudentXFamilyMapper,
			IDALStudentXFamilyMapper dalStudentXFamilyMapper)
			: base()
		{
			this.StudentXFamilyRepository = studentXFamilyRepository;
			this.StudentXFamilyModelValidator = studentXFamilyModelValidator;
			this.BolStudentXFamilyMapper = bolStudentXFamilyMapper;
			this.DalStudentXFamilyMapper = dalStudentXFamilyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStudentXFamilyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.StudentXFamilyRepository.All(limit, offset);

			return this.BolStudentXFamilyMapper.MapBOToModel(this.DalStudentXFamilyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStudentXFamilyResponseModel> Get(int id)
		{
			var record = await this.StudentXFamilyRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStudentXFamilyMapper.MapBOToModel(this.DalStudentXFamilyMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiStudentXFamilyResponseModel>> Create(
			ApiStudentXFamilyRequestModel model)
		{
			CreateResponse<ApiStudentXFamilyResponseModel> response = new CreateResponse<ApiStudentXFamilyResponseModel>(await this.StudentXFamilyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolStudentXFamilyMapper.MapModelToBO(default(int), model);
				var record = await this.StudentXFamilyRepository.Create(this.DalStudentXFamilyMapper.MapBOToEF(bo));

				response.SetRecord(this.BolStudentXFamilyMapper.MapBOToModel(this.DalStudentXFamilyMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStudentXFamilyResponseModel>> Update(
			int id,
			ApiStudentXFamilyRequestModel model)
		{
			var validationResult = await this.StudentXFamilyModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolStudentXFamilyMapper.MapModelToBO(id, model);
				await this.StudentXFamilyRepository.Update(this.DalStudentXFamilyMapper.MapBOToEF(bo));

				var record = await this.StudentXFamilyRepository.Get(id);

				return new UpdateResponse<ApiStudentXFamilyResponseModel>(this.BolStudentXFamilyMapper.MapBOToModel(this.DalStudentXFamilyMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiStudentXFamilyResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.StudentXFamilyModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.StudentXFamilyRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6537cba5f35cef922754720aa9f847be</Hash>
</Codenesium>*/