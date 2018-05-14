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

		public virtual List<POCOTeacherXTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOTeacherXTeacherSkill Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOTeacherXTeacherSkill Create(
			ApiTeacherXTeacherSkillModel model)
		{
			TeacherXTeacherSkill record = new TeacherXTeacherSkill();

			this.Mapper.TeacherXTeacherSkillMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<TeacherXTeacherSkill>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.TeacherXTeacherSkillMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiTeacherXTeacherSkillModel model)
		{
			TeacherXTeacherSkill record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
			TeacherXTeacherSkill record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TeacherXTeacherSkill>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOTeacherXTeacherSkill> Where(Expression<Func<TeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOTeacherXTeacherSkill> SearchLinqPOCO(Expression<Func<TeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTeacherXTeacherSkill> response = new List<POCOTeacherXTeacherSkill>();
			List<TeacherXTeacherSkill> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.TeacherXTeacherSkillMapEFToPOCO(x)));
			return response;
		}

		private List<TeacherXTeacherSkill> SearchLinqEF(Expression<Func<TeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TeacherXTeacherSkill.Id)} ASC";
			}
			return this.Context.Set<TeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<TeacherXTeacherSkill>();
		}

		private List<TeacherXTeacherSkill> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TeacherXTeacherSkill.Id)} ASC";
			}

			return this.Context.Set<TeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<TeacherXTeacherSkill>();
		}
	}
}

/*<Codenesium>
    <Hash>66c8c179cc81034a455c6820c2cc8603</Hash>
</Codenesium>*/