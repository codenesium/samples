using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractFamilyService: AbstractService
	{
		private IFamilyRepository familyRepository;
		private IApiFamilyRequestModelValidator familyModelValidator;
		private IBOLFamilyMapper bolFamilyMapper;
		private IDALFamilyMapper dalFamilyMapper;
		private ILogger logger;

		public AbstractFamilyService(
			ILogger logger,
			IFamilyRepository familyRepository,
			IApiFamilyRequestModelValidator familyModelValidator,
			IBOLFamilyMapper bolfamilyMapper,
			IDALFamilyMapper dalfamilyMapper)
			: base()

		{
			this.familyRepository = familyRepository;
			this.familyModelValidator = familyModelValidator;
			this.bolFamilyMapper = bolfamilyMapper;
			this.dalFamilyMapper = dalfamilyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFamilyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.familyRepository.All(skip, take, orderClause);

			return this.bolFamilyMapper.MapBOToModel(this.dalFamilyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFamilyResponseModel> Get(int id)
		{
			var record = await familyRepository.Get(id);

			return this.bolFamilyMapper.MapBOToModel(this.dalFamilyMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiFamilyResponseModel>> Create(
			ApiFamilyRequestModel model)
		{
			CreateResponse<ApiFamilyResponseModel> response = new CreateResponse<ApiFamilyResponseModel>(await this.familyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolFamilyMapper.MapModelToBO(default (int), model);
				var record = await this.familyRepository.Create(this.dalFamilyMapper.MapBOToEF(bo));

				response.SetRecord(this.bolFamilyMapper.MapBOToModel(this.dalFamilyMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiFamilyRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.familyModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolFamilyMapper.MapModelToBO(id, model);
				await this.familyRepository.Update(this.dalFamilyMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.familyModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.familyRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8a645f3c4ba4a60819c9e3369a3ca557</Hash>
</Codenesium>*/