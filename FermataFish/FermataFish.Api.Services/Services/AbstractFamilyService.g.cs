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
		private IBOLFamilyMapper BOLFamilyMapper;
		private IDALFamilyMapper DALFamilyMapper;
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
			this.BOLFamilyMapper = bolfamilyMapper;
			this.DALFamilyMapper = dalfamilyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFamilyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.familyRepository.All(skip, take, orderClause);

			return this.BOLFamilyMapper.MapBOToModel(this.DALFamilyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFamilyResponseModel> Get(int id)
		{
			var record = await familyRepository.Get(id);

			return this.BOLFamilyMapper.MapBOToModel(this.DALFamilyMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiFamilyResponseModel>> Create(
			ApiFamilyRequestModel model)
		{
			CreateResponse<ApiFamilyResponseModel> response = new CreateResponse<ApiFamilyResponseModel>(await this.familyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLFamilyMapper.MapModelToBO(default (int), model);
				var record = await this.familyRepository.Create(this.DALFamilyMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLFamilyMapper.MapBOToModel(this.DALFamilyMapper.MapEFToBO(record)));
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
				var bo = this.BOLFamilyMapper.MapModelToBO(id, model);
				await this.familyRepository.Update(this.DALFamilyMapper.MapBOToEF(bo));
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
    <Hash>c8ffd23cf087fbc43f4b42139105a815</Hash>
</Codenesium>*/