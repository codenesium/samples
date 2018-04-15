using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractTeacherSkillRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractTeacherSkillRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			TeacherSkillModel model)
		{
			var record = new EFTeacherSkill();

			this.mapper.TeacherSkillMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFTeacherSkill>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			TeacherSkillModel model)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				this.mapper.TeacherSkillMapModelToEF(
					id,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFTeacherSkill>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int id)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOTeacherSkill GetByIdDirect(int id)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.TeacherSkills.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOTeacherSkill> GetWhereDirect(Expression<Func<EFTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.TeacherSkills;
		}

		private void SearchLinqPOCO(Expression<Func<EFTeacherSkill, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFTeacherSkill> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.TeacherSkillMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFTeacherSkill> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.TeacherSkillMapEFToPOCO(x, response));
		}

		protected virtual List<EFTeacherSkill> SearchLinqEF(Expression<Func<EFTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTeacherSkill> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>365b3dfc9c5ab39a2a70e7b4735d8d1f</Hash>
</Codenesium>*/