import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
import { WrappedAdminCreateComponent } from './components/admin/adminCreateForm';
import { WrappedAdminDetailComponent } from './components/admin/adminDetailForm';
import { WrappedAdminEditComponent } from './components/admin/adminEditForm';
import { WrappedAdminSearchComponent } from './components/admin/adminSearchForm';
import { WrappedEventCreateComponent } from './components/event/eventCreateForm';
import { WrappedEventDetailComponent } from './components/event/eventDetailForm';
import { WrappedEventEditComponent } from './components/event/eventEditForm';
import { WrappedEventSearchComponent } from './components/event/eventSearchForm';
import { WrappedEventStatuCreateComponent } from './components/eventStatu/eventStatuCreateForm';
import { WrappedEventStatuDetailComponent } from './components/eventStatu/eventStatuDetailForm';
import { WrappedEventStatuEditComponent } from './components/eventStatu/eventStatuEditForm';
import { WrappedEventStatuSearchComponent } from './components/eventStatu/eventStatuSearchForm';
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
import { WrappedUserCreateComponent } from './components/user/userCreateForm';
import { WrappedUserDetailComponent } from './components/user/userDetailForm';
import { WrappedUserEditComponent } from './components/user/userEditForm';
import { WrappedUserSearchComponent } from './components/user/userSearchForm';

const config = {
  oidc: {
    clientId: '<okta_client_id>',
    issuer: 'https://<okta_application_url>/oauth2/default',
    redirectUri: 'https://<your_public_webserver>/implicit/callback',
    scope: 'openid profile email',
  },
};

export const AppRouter: React.StatelessComponent<{}> = () => {
  const query = new URLSearchParams(location.search);

  return (
    <BrowserRouter>
      <Security
        issuer={config.oidc.issuer}
        client_id={config.oidc.clientId}
        redirect_uri={config.oidc.redirectUri}
      >
        <SecureRoute
          path="/protected"
          component={() => '<div>secure route</div>'}
        />
        <Switch>
          <Route exact path="/" component={wrapperHeader(Dashboard)} />
          <Route
            path={ClientRoutes.Admins + '/create'}
            component={wrapperHeader(WrappedAdminCreateComponent)}
          />
          <Route
            path={ClientRoutes.Admins + '/edit/:id'}
            component={wrapperHeader(WrappedAdminEditComponent)}
          />
          <Route
            path={ClientRoutes.Admins + '/:id'}
            component={wrapperHeader(WrappedAdminDetailComponent)}
          />
          <Route
            path={ClientRoutes.Admins}
            component={wrapperHeader(WrappedAdminSearchComponent)}
          />
          <Route
            path={ClientRoutes.Events + '/create'}
            component={wrapperHeader(WrappedEventCreateComponent)}
          />
          <Route
            path={ClientRoutes.Events + '/edit/:id'}
            component={wrapperHeader(WrappedEventEditComponent)}
          />
          <Route
            path={ClientRoutes.Events + '/:id'}
            component={wrapperHeader(WrappedEventDetailComponent)}
          />
          <Route
            path={ClientRoutes.Events}
            component={wrapperHeader(WrappedEventSearchComponent)}
          />
          <Route
            path={ClientRoutes.EventStatus + '/create'}
            component={wrapperHeader(WrappedEventStatuCreateComponent)}
          />
          <Route
            path={ClientRoutes.EventStatus + '/edit/:id'}
            component={wrapperHeader(WrappedEventStatuEditComponent)}
          />
          <Route
            path={ClientRoutes.EventStatus + '/:id'}
            component={wrapperHeader(WrappedEventStatuDetailComponent)}
          />
          <Route
            path={ClientRoutes.EventStatus}
            component={wrapperHeader(WrappedEventStatuSearchComponent)}
          />
          <Route
            path={ClientRoutes.Families + '/create'}
            component={wrapperHeader(WrappedFamilyCreateComponent)}
          />
          <Route
            path={ClientRoutes.Families + '/edit/:id'}
            component={wrapperHeader(WrappedFamilyEditComponent)}
          />
          <Route
            path={ClientRoutes.Families + '/:id'}
            component={wrapperHeader(WrappedFamilyDetailComponent)}
          />
          <Route
            path={ClientRoutes.Families}
            component={wrapperHeader(WrappedFamilySearchComponent)}
          />
          <Route
            path={ClientRoutes.Rates + '/create'}
            component={wrapperHeader(WrappedRateCreateComponent)}
          />
          <Route
            path={ClientRoutes.Rates + '/edit/:id'}
            component={wrapperHeader(WrappedRateEditComponent)}
          />
          <Route
            path={ClientRoutes.Rates + '/:id'}
            component={wrapperHeader(WrappedRateDetailComponent)}
          />
          <Route
            path={ClientRoutes.Rates}
            component={wrapperHeader(WrappedRateSearchComponent)}
          />
          <Route
            path={ClientRoutes.Spaces + '/create'}
            component={wrapperHeader(WrappedSpaceCreateComponent)}
          />
          <Route
            path={ClientRoutes.Spaces + '/edit/:id'}
            component={wrapperHeader(WrappedSpaceEditComponent)}
          />
          <Route
            path={ClientRoutes.Spaces + '/:id'}
            component={wrapperHeader(WrappedSpaceDetailComponent)}
          />
          <Route
            path={ClientRoutes.Spaces}
            component={wrapperHeader(WrappedSpaceSearchComponent)}
          />
          <Route
            path={ClientRoutes.SpaceFeatures + '/create'}
            component={wrapperHeader(WrappedSpaceFeatureCreateComponent)}
          />
          <Route
            path={ClientRoutes.SpaceFeatures + '/edit/:id'}
            component={wrapperHeader(WrappedSpaceFeatureEditComponent)}
          />
          <Route
            path={ClientRoutes.SpaceFeatures + '/:id'}
            component={wrapperHeader(WrappedSpaceFeatureDetailComponent)}
          />
          <Route
            path={ClientRoutes.SpaceFeatures}
            component={wrapperHeader(WrappedSpaceFeatureSearchComponent)}
          />
          <Route
            path={ClientRoutes.Students + '/create'}
            component={wrapperHeader(WrappedStudentCreateComponent)}
          />
          <Route
            path={ClientRoutes.Students + '/edit/:id'}
            component={wrapperHeader(WrappedStudentEditComponent)}
          />
          <Route
            path={ClientRoutes.Students + '/:id'}
            component={wrapperHeader(WrappedStudentDetailComponent)}
          />
          <Route
            path={ClientRoutes.Students}
            component={wrapperHeader(WrappedStudentSearchComponent)}
          />
          <Route
            path={ClientRoutes.Studios + '/create'}
            component={wrapperHeader(WrappedStudioCreateComponent)}
          />
          <Route
            path={ClientRoutes.Studios + '/edit/:id'}
            component={wrapperHeader(WrappedStudioEditComponent)}
          />
          <Route
            path={ClientRoutes.Studios + '/:id'}
            component={wrapperHeader(WrappedStudioDetailComponent)}
          />
          <Route
            path={ClientRoutes.Studios}
            component={wrapperHeader(WrappedStudioSearchComponent)}
          />
          <Route
            path={ClientRoutes.Teachers + '/create'}
            component={wrapperHeader(WrappedTeacherCreateComponent)}
          />
          <Route
            path={ClientRoutes.Teachers + '/edit/:id'}
            component={wrapperHeader(WrappedTeacherEditComponent)}
          />
          <Route
            path={ClientRoutes.Teachers + '/:id'}
            component={wrapperHeader(WrappedTeacherDetailComponent)}
          />
          <Route
            path={ClientRoutes.Teachers}
            component={wrapperHeader(WrappedTeacherSearchComponent)}
          />
          <Route
            path={ClientRoutes.TeacherSkills + '/create'}
            component={wrapperHeader(WrappedTeacherSkillCreateComponent)}
          />
          <Route
            path={ClientRoutes.TeacherSkills + '/edit/:id'}
            component={wrapperHeader(WrappedTeacherSkillEditComponent)}
          />
          <Route
            path={ClientRoutes.TeacherSkills + '/:id'}
            component={wrapperHeader(WrappedTeacherSkillDetailComponent)}
          />
          <Route
            path={ClientRoutes.TeacherSkills}
            component={wrapperHeader(WrappedTeacherSkillSearchComponent)}
          />
          <Route
            path={ClientRoutes.Users + '/create'}
            component={wrapperHeader(WrappedUserCreateComponent)}
          />
          <Route
            path={ClientRoutes.Users + '/edit/:id'}
            component={wrapperHeader(WrappedUserEditComponent)}
          />
          <Route
            path={ClientRoutes.Users + '/:id'}
            component={wrapperHeader(WrappedUserDetailComponent)}
          />
          <Route
            path={ClientRoutes.Users}
            component={wrapperHeader(WrappedUserSearchComponent)}
          />
        </Switch>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>d452da0a2e6f312b1980242d3536d3ba</Hash>
</Codenesium>*/