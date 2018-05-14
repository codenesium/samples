using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void AdminMapModelToEF(
			int id,
			ApiAdminModel model,
			Admin efAdmin);

		POCOAdmin AdminMapEFToPOCO(
			Admin efAdmin);

		void FamilyMapModelToEF(
			int id,
			ApiFamilyModel model,
			Family efFamily);

		POCOFamily FamilyMapEFToPOCO(
			Family efFamily);

		void LessonMapModelToEF(
			int id,
			ApiLessonModel model,
			Lesson efLesson);

		POCOLesson LessonMapEFToPOCO(
			Lesson efLesson);

		void LessonStatusMapModelToEF(
			int id,
			ApiLessonStatusModel model,
			LessonStatus efLessonStatus);

		POCOLessonStatus LessonStatusMapEFToPOCO(
			LessonStatus efLessonStatus);

		void LessonXStudentMapModelToEF(
			int id,
			ApiLessonXStudentModel model,
			LessonXStudent efLessonXStudent);

		POCOLessonXStudent LessonXStudentMapEFToPOCO(
			LessonXStudent efLessonXStudent);

		void LessonXTeacherMapModelToEF(
			int id,
			ApiLessonXTeacherModel model,
			LessonXTeacher efLessonXTeacher);

		POCOLessonXTeacher LessonXTeacherMapEFToPOCO(
			LessonXTeacher efLessonXTeacher);

		void RateMapModelToEF(
			int id,
			ApiRateModel model,
			Rate efRate);

		POCORate RateMapEFToPOCO(
			Rate efRate);

		void SpaceMapModelToEF(
			int id,
			ApiSpaceModel model,
			Space efSpace);

		POCOSpace SpaceMapEFToPOCO(
			Space efSpace);

		void SpaceFeatureMapModelToEF(
			int id,
			ApiSpaceFeatureModel model,
			SpaceFeature efSpaceFeature);

		POCOSpaceFeature SpaceFeatureMapEFToPOCO(
			SpaceFeature efSpaceFeature);

		void SpaceXSpaceFeatureMapModelToEF(
			int id,
			ApiSpaceXSpaceFeatureModel model,
			SpaceXSpaceFeature efSpaceXSpaceFeature);

		POCOSpaceXSpaceFeature SpaceXSpaceFeatureMapEFToPOCO(
			SpaceXSpaceFeature efSpaceXSpaceFeature);

		void StateMapModelToEF(
			int id,
			ApiStateModel model,
			State efState);

		POCOState StateMapEFToPOCO(
			State efState);

		void StudentMapModelToEF(
			int id,
			ApiStudentModel model,
			Student efStudent);

		POCOStudent StudentMapEFToPOCO(
			Student efStudent);

		void StudentXFamilyMapModelToEF(
			int id,
			ApiStudentXFamilyModel model,
			StudentXFamily efStudentXFamily);

		POCOStudentXFamily StudentXFamilyMapEFToPOCO(
			StudentXFamily efStudentXFamily);

		void StudioMapModelToEF(
			int id,
			ApiStudioModel model,
			Studio efStudio);

		POCOStudio StudioMapEFToPOCO(
			Studio efStudio);

		void TeacherMapModelToEF(
			int id,
			ApiTeacherModel model,
			Teacher efTeacher);

		POCOTeacher TeacherMapEFToPOCO(
			Teacher efTeacher);

		void TeacherSkillMapModelToEF(
			int id,
			ApiTeacherSkillModel model,
			TeacherSkill efTeacherSkill);

		POCOTeacherSkill TeacherSkillMapEFToPOCO(
			TeacherSkill efTeacherSkill);

		void TeacherXTeacherSkillMapModelToEF(
			int id,
			ApiTeacherXTeacherSkillModel model,
			TeacherXTeacherSkill efTeacherXTeacherSkill);

		POCOTeacherXTeacherSkill TeacherXTeacherSkillMapEFToPOCO(
			TeacherXTeacherSkill efTeacherXTeacherSkill);
	}
}

/*<Codenesium>
    <Hash>8bbe3c9072f7fe7c4a0631b4ecabd8c8</Hash>
</Codenesium>*/