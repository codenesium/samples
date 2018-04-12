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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractTeacherXTeacherSkillRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			int teacherId,
			int teacherSkillId)
		{
			var record = new EFTeacherXTeacherSkill();

			MapPOCOToEF(
				0,
				teacherId,
				teacherSkillId,
				record);

			this.context.Set<EFTeacherXTeacherSkill>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			int teacherId,
			int teacherSkillId)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				MapPOCOToEF(
					id,
					teacherId,
					teacherSkillId,
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
				this.context.Set<EFTeacherXTeacherSkill>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOTeacherXTeacherSkill GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.TeacherXTeacherSkills.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOTeacherXTeacherSkill> GetWhereDirect(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.TeacherXTeacherSkills;
		}

		private void SearchLinqPOCO(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFTeacherXTeacherSkill> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFTeacherXTeacherSkill> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFTeacherXTeacherSkill> SearchLinqEF(Expression<Func<EFTeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFTeacherXTeacherSkill> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int id,
			int teacherId,
			int teacherSkillId,
			EFTeacherXTeacherSkill efTeacherXTeacherSkill)
		{
			efTeacherXTeacherSkill.SetProperties(id.ToInt(), teacherId.ToInt(), teacherSkillId.ToInt());
		}

		public static void MapEFToPOCO(
			EFTeacherXTeacherSkill efTeacherXTeacherSkill,
			Response response)
		{
			if (efTeacherXTeacherSkill == null)
			{
				return;
			}

			response.AddTeacherXTeacherSkill(new POCOTeacherXTeacherSkill(efTeacherXTeacherSkill.Id.ToInt(), efTeacherXTeacherSkill.TeacherId.ToInt(), efTeacherXTeacherSkill.TeacherSkillId.ToInt()));

			TeacherRepository.MapEFToPOCO(efTeacherXTeacherSkill.Teacher, response);

			TeacherSkillRepository.MapEFToPOCO(efTeacherXTeacherSkill.TeacherSkill, response);
		}
	}
}

/*<Codenesium>
    <Hash>148d2513eefec880cb518a920ec38d30</Hash>
</Codenesium>*/