import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { wrapperHeader } from './components/header';
import { wrapperAuthHeader } from './components/auth/authHeader';
import { AuthClientRoutes, ClientRoutes, Constants } from './constants';
import { WrappedLoginComponent } from './components/auth/loginForm';
import { WrappedLogoutComponent } from './components/auth/logoutForm';
import { WrappedRegisterComponent } from './components/auth/registerForm';
import { WrappedResetPasswordComponent } from './components/auth/resetPasswordForm';
import { WrappedConfirmPasswordResetComponent } from './components/auth/confirmPasswordResetForm';
import { WrappedConfirmRegistrationComponent } from './components/auth/confirmRegistrationForm';
import { WrappedChangePasswordComponent } from './components/auth/changePasswordForm';
import { WrappedChangeEmailComponent } from './components/auth/changeEmailForm';
import { WrappedConfirmChangeEmailComponent } from './components/auth/confirmChangeEmailForm';
import { WrappedAdminCreateComponent } from './components/admin/adminCreateForm';
import { WrappedAdminDetailComponent } from './components/admin/adminDetailForm';
import { WrappedAdminEditComponent } from './components/admin/adminEditForm';
import { WrappedAdminSearchComponent } from './components/admin/adminSearchForm';
import { WrappedEventCreateComponent } from './components/event/eventCreateForm';
import { WrappedEventDetailComponent } from './components/event/eventDetailForm';
import { WrappedEventEditComponent } from './components/event/eventEditForm';
import { WrappedEventSearchComponent } from './components/event/eventSearchForm';
import { WrappedEventStatusCreateComponent } from './components/eventStatus/eventStatusCreateForm';
import { WrappedEventStatusDetailComponent } from './components/eventStatus/eventStatusDetailForm';
import { WrappedEventStatusEditComponent } from './components/eventStatus/eventStatusEditForm';
import { WrappedEventStatusSearchComponent } from './components/eventStatus/eventStatusSearchForm';
import { WrappedEventStudentCreateComponent } from './components/eventStudent/eventStudentCreateForm';
import { WrappedEventStudentDetailComponent } from './components/eventStudent/eventStudentDetailForm';
import { WrappedEventStudentEditComponent } from './components/eventStudent/eventStudentEditForm';
import { WrappedEventStudentSearchComponent } from './components/eventStudent/eventStudentSearchForm';
import { WrappedEventTeacherCreateComponent } from './components/eventTeacher/eventTeacherCreateForm';
import { WrappedEventTeacherDetailComponent } from './components/eventTeacher/eventTeacherDetailForm';
import { WrappedEventTeacherEditComponent } from './components/eventTeacher/eventTeacherEditForm';
import { WrappedEventTeacherSearchComponent } from './components/eventTeacher/eventTeacherSearchForm';
import { WrappedFamilyCreateComponent } from './components/family/familyCreateForm';
import { WrappedFamilyDetailComponent } from './components/family/familyDetailForm';
import { WrappedFamilyEditComponent } from './components/family/familyEditForm';
import { WrappedFamilySearchComponent } from './components/family/familySearchForm';
import { WrappedRateCreateComponent } from './components/rate/rateCreateForm';
import { WrappedRateDetailComponent } from './components/rate/rateDetailForm';
import { WrappedRateEditComponent } from './components/rate/rateEditForm';
import { WrappedRateSearchComponent } from './components/rate/rateSearchForm';
import { WrappedSpaceCreateComponent } from './components/space/spaceCreateForm';
import { WrappedSpaceDetailComponent } from './components/space/spaceDetailForm';
import { WrappedSpaceEditComponent } from './components/space/spaceEditForm';
import { WrappedSpaceSearchComponent } from './components/space/spaceSearchForm';
import { WrappedSpaceFeatureCreateComponent } from './components/spaceFeature/spaceFeatureCreateForm';
import { WrappedSpaceFeatureDetailComponent } from './components/spaceFeature/spaceFeatureDetailForm';
import { WrappedSpaceFeatureEditComponent } from './components/spaceFeature/spaceFeatureEditForm';
import { WrappedSpaceFeatureSearchComponent } from './components/spaceFeature/spaceFeatureSearchForm';
import { WrappedSpaceSpaceFeatureCreateComponent } from './components/spaceSpaceFeature/spaceSpaceFeatureCreateForm';
import { WrappedSpaceSpaceFeatureDetailComponent } from './components/spaceSpaceFeature/spaceSpaceFeatureDetailForm';
import { WrappedSpaceSpaceFeatureEditComponent } from './components/spaceSpaceFeature/spaceSpaceFeatureEditForm';
import { WrappedSpaceSpaceFeatureSearchComponent } from './components/spaceSpaceFeature/spaceSpaceFeatureSearchForm';
import { WrappedStudentCreateComponent } from './components/student/studentCreateForm';
import { WrappedStudentDetailComponent } from './components/student/studentDetailForm';
import { WrappedStudentEditComponent } from './components/student/studentEditForm';
import { WrappedStudentSearchComponent } from './components/student/studentSearchForm';
import { WrappedStudioCreateComponent } from './components/studio/studioCreateForm';
import { WrappedStudioDetailComponent } from './components/studio/studioDetailForm';
import { WrappedStudioEditComponent } from './components/studio/studioEditForm';
import { WrappedStudioSearchComponent } from './components/studio/studioSearchForm';
import { WrappedTeacherCreateComponent } from './components/teacher/teacherCreateForm';
import { WrappedTeacherDetailComponent } from './components/teacher/teacherDetailForm';
import { WrappedTeacherEditComponent } from './components/teacher/teacherEditForm';
import { WrappedTeacherSearchComponent } from './components/teacher/teacherSearchForm';
import { WrappedTeacherSkillCreateComponent } from './components/teacherSkill/teacherSkillCreateForm';
import { WrappedTeacherSkillDetailComponent } from './components/teacherSkill/teacherSkillDetailForm';
import { WrappedTeacherSkillEditComponent } from './components/teacherSkill/teacherSkillEditForm';
import { WrappedTeacherSkillSearchComponent } from './components/teacherSkill/teacherSkillSearchForm';
import { WrappedTeacherTeacherSkillCreateComponent } from './components/teacherTeacherSkill/teacherTeacherSkillCreateForm';
import { WrappedTeacherTeacherSkillDetailComponent } from './components/teacherTeacherSkill/teacherTeacherSkillDetailForm';
import { WrappedTeacherTeacherSkillEditComponent } from './components/teacherTeacherSkill/teacherTeacherSkillEditForm';
import { WrappedTeacherTeacherSkillSearchComponent } from './components/teacherTeacherSkill/teacherTeacherSkillSearchForm';
import { WrappedTenantCreateComponent } from './components/tenant/tenantCreateForm';
import { WrappedTenantDetailComponent } from './components/tenant/tenantDetailForm';
import { WrappedTenantEditComponent } from './components/tenant/tenantEditForm';
import { WrappedTenantSearchComponent } from './components/tenant/tenantSearchForm';
import { WrappedUserCreateComponent } from './components/user/userCreateForm';
import { WrappedUserDetailComponent } from './components/user/userDetailForm';
import { WrappedUserEditComponent } from './components/user/userEditForm';
import { WrappedUserSearchComponent } from './components/user/userSearchForm';

export const AppRouter: React.StatelessComponent<{}> = () => {
  return (
    <BrowserRouter basename={Constants.HostedSubDirectory}>
      <Switch>
        <Route
          exact
          path={AuthClientRoutes.ConfirmPasswordReset + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmPasswordResetComponent,
            'Confirm Password Reset'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ConfirmRegistration + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmRegistrationComponent,
            'Confirm Registration'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.Login}
          component={wrapperAuthHeader(WrappedLoginComponent, 'Login')}
        />
        <Route
          exact
          path={AuthClientRoutes.Logout}
          component={wrapperAuthHeader(WrappedLogoutComponent, 'Logout')}
        />
        <Route
          exact
          path={AuthClientRoutes.Register}
          component={wrapperAuthHeader(WrappedRegisterComponent, 'Register')}
        />
        <Route
          exact
          path={AuthClientRoutes.ResetPassword}
          component={wrapperAuthHeader(
            WrappedResetPasswordComponent,
            'Reset Password'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ChangePassword}
          component={wrapperHeader(
            WrappedChangePasswordComponent,
            'Change Password'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ChangeEmail}
          component={wrapperHeader(WrappedChangeEmailComponent, 'Change Email')}
        />
        <Route
          exact
          path={AuthClientRoutes.ConfirmChangeEmail + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmChangeEmailComponent,
            'Confirm Email Change'
          )}
        />
        <Route
          exact
          path="/"
          component={wrapperHeader(Dashboard, 'Dashboard')}
        />
        <Route
          path={ClientRoutes.Admins + '/create'}
          component={wrapperHeader(WrappedAdminCreateComponent, 'Admin Create')}
        />
        <Route
          path={ClientRoutes.Admins + '/edit/:id'}
          component={wrapperHeader(WrappedAdminEditComponent, 'Admin Edit')}
        />
        <Route
          path={ClientRoutes.Admins + '/:id'}
          component={wrapperHeader(WrappedAdminDetailComponent, 'Admin Detail')}
        />
        <Route
          path={ClientRoutes.Admins}
          component={wrapperHeader(WrappedAdminSearchComponent, 'Admin Search')}
        />
        <Route
          path={ClientRoutes.Events + '/create'}
          component={wrapperHeader(WrappedEventCreateComponent, 'Event Create')}
        />
        <Route
          path={ClientRoutes.Events + '/edit/:id'}
          component={wrapperHeader(WrappedEventEditComponent, 'Event Edit')}
        />
        <Route
          path={ClientRoutes.Events + '/:id'}
          component={wrapperHeader(WrappedEventDetailComponent, 'Event Detail')}
        />
        <Route
          path={ClientRoutes.Events}
          component={wrapperHeader(WrappedEventSearchComponent, 'Event Search')}
        />
        <Route
          path={ClientRoutes.EventStatus + '/create'}
          component={wrapperHeader(
            WrappedEventStatusCreateComponent,
            'Event Status Create'
          )}
        />
        <Route
          path={ClientRoutes.EventStatus + '/edit/:id'}
          component={wrapperHeader(
            WrappedEventStatusEditComponent,
            'Event Status Edit'
          )}
        />
        <Route
          path={ClientRoutes.EventStatus + '/:id'}
          component={wrapperHeader(
            WrappedEventStatusDetailComponent,
            'Event Status Detail'
          )}
        />
        <Route
          path={ClientRoutes.EventStatus}
          component={wrapperHeader(
            WrappedEventStatusSearchComponent,
            'Event Status Search'
          )}
        />
        <Route
          path={ClientRoutes.EventStudents + '/create'}
          component={wrapperHeader(
            WrappedEventStudentCreateComponent,
            'EventStudents Create'
          )}
        />
        <Route
          path={ClientRoutes.EventStudents + '/edit/:id'}
          component={wrapperHeader(
            WrappedEventStudentEditComponent,
            'EventStudents Edit'
          )}
        />
        <Route
          path={ClientRoutes.EventStudents + '/:id'}
          component={wrapperHeader(
            WrappedEventStudentDetailComponent,
            'EventStudents Detail'
          )}
        />
        <Route
          path={ClientRoutes.EventStudents}
          component={wrapperHeader(
            WrappedEventStudentSearchComponent,
            'EventStudents Search'
          )}
        />
        <Route
          path={ClientRoutes.EventTeachers + '/create'}
          component={wrapperHeader(
            WrappedEventTeacherCreateComponent,
            'EventTeachers Create'
          )}
        />
        <Route
          path={ClientRoutes.EventTeachers + '/edit/:id'}
          component={wrapperHeader(
            WrappedEventTeacherEditComponent,
            'EventTeachers Edit'
          )}
        />
        <Route
          path={ClientRoutes.EventTeachers + '/:id'}
          component={wrapperHeader(
            WrappedEventTeacherDetailComponent,
            'EventTeachers Detail'
          )}
        />
        <Route
          path={ClientRoutes.EventTeachers}
          component={wrapperHeader(
            WrappedEventTeacherSearchComponent,
            'EventTeachers Search'
          )}
        />
        <Route
          path={ClientRoutes.Families + '/create'}
          component={wrapperHeader(
            WrappedFamilyCreateComponent,
            'Family Create'
          )}
        />
        <Route
          path={ClientRoutes.Families + '/edit/:id'}
          component={wrapperHeader(WrappedFamilyEditComponent, 'Family Edit')}
        />
        <Route
          path={ClientRoutes.Families + '/:id'}
          component={wrapperHeader(
            WrappedFamilyDetailComponent,
            'Family Detail'
          )}
        />
        <Route
          path={ClientRoutes.Families}
          component={wrapperHeader(
            WrappedFamilySearchComponent,
            'Family Search'
          )}
        />
        <Route
          path={ClientRoutes.Rates + '/create'}
          component={wrapperHeader(WrappedRateCreateComponent, 'Rate Create')}
        />
        <Route
          path={ClientRoutes.Rates + '/edit/:id'}
          component={wrapperHeader(WrappedRateEditComponent, 'Rate Edit')}
        />
        <Route
          path={ClientRoutes.Rates + '/:id'}
          component={wrapperHeader(WrappedRateDetailComponent, 'Rate Detail')}
        />
        <Route
          path={ClientRoutes.Rates}
          component={wrapperHeader(WrappedRateSearchComponent, 'Rate Search')}
        />
        <Route
          path={ClientRoutes.Spaces + '/create'}
          component={wrapperHeader(WrappedSpaceCreateComponent, 'Space Create')}
        />
        <Route
          path={ClientRoutes.Spaces + '/edit/:id'}
          component={wrapperHeader(WrappedSpaceEditComponent, 'Space Edit')}
        />
        <Route
          path={ClientRoutes.Spaces + '/:id'}
          component={wrapperHeader(WrappedSpaceDetailComponent, 'Space Detail')}
        />
        <Route
          path={ClientRoutes.Spaces}
          component={wrapperHeader(WrappedSpaceSearchComponent, 'Space Search')}
        />
        <Route
          path={ClientRoutes.SpaceFeatures + '/create'}
          component={wrapperHeader(
            WrappedSpaceFeatureCreateComponent,
            'Space Feature Create'
          )}
        />
        <Route
          path={ClientRoutes.SpaceFeatures + '/edit/:id'}
          component={wrapperHeader(
            WrappedSpaceFeatureEditComponent,
            'Space Feature Edit'
          )}
        />
        <Route
          path={ClientRoutes.SpaceFeatures + '/:id'}
          component={wrapperHeader(
            WrappedSpaceFeatureDetailComponent,
            'Space Feature Detail'
          )}
        />
        <Route
          path={ClientRoutes.SpaceFeatures}
          component={wrapperHeader(
            WrappedSpaceFeatureSearchComponent,
            'Space Feature Search'
          )}
        />
        <Route
          path={ClientRoutes.SpaceSpaceFeatures + '/create'}
          component={wrapperHeader(
            WrappedSpaceSpaceFeatureCreateComponent,
            'SpaceSpaceFeatures Create'
          )}
        />
        <Route
          path={ClientRoutes.SpaceSpaceFeatures + '/edit/:id'}
          component={wrapperHeader(
            WrappedSpaceSpaceFeatureEditComponent,
            'SpaceSpaceFeatures Edit'
          )}
        />
        <Route
          path={ClientRoutes.SpaceSpaceFeatures + '/:id'}
          component={wrapperHeader(
            WrappedSpaceSpaceFeatureDetailComponent,
            'SpaceSpaceFeatures Detail'
          )}
        />
        <Route
          path={ClientRoutes.SpaceSpaceFeatures}
          component={wrapperHeader(
            WrappedSpaceSpaceFeatureSearchComponent,
            'SpaceSpaceFeatures Search'
          )}
        />
        <Route
          path={ClientRoutes.Students + '/create'}
          component={wrapperHeader(
            WrappedStudentCreateComponent,
            'Student Create'
          )}
        />
        <Route
          path={ClientRoutes.Students + '/edit/:id'}
          component={wrapperHeader(WrappedStudentEditComponent, 'Student Edit')}
        />
        <Route
          path={ClientRoutes.Students + '/:id'}
          component={wrapperHeader(
            WrappedStudentDetailComponent,
            'Student Detail'
          )}
        />
        <Route
          path={ClientRoutes.Students}
          component={wrapperHeader(
            WrappedStudentSearchComponent,
            'Student Search'
          )}
        />
        <Route
          path={ClientRoutes.Studios + '/create'}
          component={wrapperHeader(
            WrappedStudioCreateComponent,
            'Studio Create'
          )}
        />
        <Route
          path={ClientRoutes.Studios + '/edit/:id'}
          component={wrapperHeader(WrappedStudioEditComponent, 'Studio Edit')}
        />
        <Route
          path={ClientRoutes.Studios + '/:id'}
          component={wrapperHeader(
            WrappedStudioDetailComponent,
            'Studio Detail'
          )}
        />
        <Route
          path={ClientRoutes.Studios}
          component={wrapperHeader(
            WrappedStudioSearchComponent,
            'Studio Search'
          )}
        />
        <Route
          path={ClientRoutes.Teachers + '/create'}
          component={wrapperHeader(
            WrappedTeacherCreateComponent,
            'Teacher Create'
          )}
        />
        <Route
          path={ClientRoutes.Teachers + '/edit/:id'}
          component={wrapperHeader(WrappedTeacherEditComponent, 'Teacher Edit')}
        />
        <Route
          path={ClientRoutes.Teachers + '/:id'}
          component={wrapperHeader(
            WrappedTeacherDetailComponent,
            'Teacher Detail'
          )}
        />
        <Route
          path={ClientRoutes.Teachers}
          component={wrapperHeader(
            WrappedTeacherSearchComponent,
            'Teacher Search'
          )}
        />
        <Route
          path={ClientRoutes.TeacherSkills + '/create'}
          component={wrapperHeader(
            WrappedTeacherSkillCreateComponent,
            'Teacher Skill Create'
          )}
        />
        <Route
          path={ClientRoutes.TeacherSkills + '/edit/:id'}
          component={wrapperHeader(
            WrappedTeacherSkillEditComponent,
            'Teacher Skill Edit'
          )}
        />
        <Route
          path={ClientRoutes.TeacherSkills + '/:id'}
          component={wrapperHeader(
            WrappedTeacherSkillDetailComponent,
            'Teacher Skill Detail'
          )}
        />
        <Route
          path={ClientRoutes.TeacherSkills}
          component={wrapperHeader(
            WrappedTeacherSkillSearchComponent,
            'Teacher Skill Search'
          )}
        />
        <Route
          path={ClientRoutes.TeacherTeacherSkills + '/create'}
          component={wrapperHeader(
            WrappedTeacherTeacherSkillCreateComponent,
            'TeacherTeacherSkills Create'
          )}
        />
        <Route
          path={ClientRoutes.TeacherTeacherSkills + '/edit/:id'}
          component={wrapperHeader(
            WrappedTeacherTeacherSkillEditComponent,
            'TeacherTeacherSkills Edit'
          )}
        />
        <Route
          path={ClientRoutes.TeacherTeacherSkills + '/:id'}
          component={wrapperHeader(
            WrappedTeacherTeacherSkillDetailComponent,
            'TeacherTeacherSkills Detail'
          )}
        />
        <Route
          path={ClientRoutes.TeacherTeacherSkills}
          component={wrapperHeader(
            WrappedTeacherTeacherSkillSearchComponent,
            'TeacherTeacherSkills Search'
          )}
        />
        <Route
          path={ClientRoutes.Tenants + '/create'}
          component={wrapperHeader(
            WrappedTenantCreateComponent,
            'Tenant Create'
          )}
        />
        <Route
          path={ClientRoutes.Tenants + '/edit/:id'}
          component={wrapperHeader(WrappedTenantEditComponent, 'Tenant Edit')}
        />
        <Route
          path={ClientRoutes.Tenants + '/:id'}
          component={wrapperHeader(
            WrappedTenantDetailComponent,
            'Tenant Detail'
          )}
        />
        <Route
          path={ClientRoutes.Tenants}
          component={wrapperHeader(
            WrappedTenantSearchComponent,
            'Tenant Search'
          )}
        />
        <Route
          path={ClientRoutes.Users + '/create'}
          component={wrapperHeader(WrappedUserCreateComponent, 'User Create')}
        />
        <Route
          path={ClientRoutes.Users + '/edit/:id'}
          component={wrapperHeader(WrappedUserEditComponent, 'User Edit')}
        />
        <Route
          path={ClientRoutes.Users + '/:id'}
          component={wrapperHeader(WrappedUserDetailComponent, 'User Detail')}
        />
        <Route
          path={ClientRoutes.Users}
          component={wrapperHeader(WrappedUserSearchComponent, 'User Search')}
        />
        <Route render={() => <div>No handler for route found...</div>} />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>2e69f05b68b1078b9fc4cf588f281095</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/