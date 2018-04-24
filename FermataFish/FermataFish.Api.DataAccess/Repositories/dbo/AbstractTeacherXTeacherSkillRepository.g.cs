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
	public abstract class AbstractTeacherXTeacherSkillRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTeacherXTeacherSkillRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			TeacherXTeacherSkillModel model)
		{
			EFTeacherXTeacherSkill record = new EFTeacherXTeacherSkill();

			this.Mapper.TeacherXTeacherSkillMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFTeacherXTeacherSkill>().Add(record);
			this.Context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			TeacherXTeacherSkillModel model)
		{
			EFTeacherXTeacherSkill record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.TeacherXTeacherSkillMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			EFTeacherXTeacherSkill record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFTeacherXTeacherSkill>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id);
		}

		public virtual POCOTeacherXTeacherSkill GetByIdDirect(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).TeacherXTeacherSkills.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOTeacherXTeacherSkill> GetWhereDirect(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).TeacherXTeacherSkills;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFTeacherXTeacherSkill> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.TeacherXTeacherSkillMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFTeacherXTeacherSkill> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.TeacherXTeacherSkillMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFTeacherXTeacherSkill> SearchLinqEF(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTeacherXTeacherSkill> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>3e782567c70115aa86e38403db5ee028</Hash>
</Codenesium>*/