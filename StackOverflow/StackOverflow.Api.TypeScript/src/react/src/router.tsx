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
import { WrappedBadgeCreateComponent } from './components/badge/badgeCreateForm';
import { WrappedBadgeDetailComponent } from './components/badge/badgeDetailForm';
import { WrappedBadgeEditComponent } from './components/badge/badgeEditForm';
import { WrappedBadgeSearchComponent } from './components/badge/badgeSearchForm';
import { WrappedCommentCreateComponent } from './components/comment/commentCreateForm';
import { WrappedCommentDetailComponent } from './components/comment/commentDetailForm';
import { WrappedCommentEditComponent } from './components/comment/commentEditForm';
import { WrappedCommentSearchComponent } from './components/comment/commentSearchForm';
import { WrappedLinkTypeCreateComponent } from './components/linkType/linkTypeCreateForm';
import { WrappedLinkTypeDetailComponent } from './components/linkType/linkTypeDetailForm';
import { WrappedLinkTypeEditComponent } from './components/linkType/linkTypeEditForm';
import { WrappedLinkTypeSearchComponent } from './components/linkType/linkTypeSearchForm';
import { WrappedPostHistoryCreateComponent } from './components/postHistory/postHistoryCreateForm';
import { WrappedPostHistoryDetailComponent } from './components/postHistory/postHistoryDetailForm';
import { WrappedPostHistoryEditComponent } from './components/postHistory/postHistoryEditForm';
import { WrappedPostHistorySearchComponent } from './components/postHistory/postHistorySearchForm';
import { WrappedPostHistoryTypeCreateComponent } from './components/postHistoryType/postHistoryTypeCreateForm';
import { WrappedPostHistoryTypeDetailComponent } from './components/postHistoryType/postHistoryTypeDetailForm';
import { WrappedPostHistoryTypeEditComponent } from './components/postHistoryType/postHistoryTypeEditForm';
import { WrappedPostHistoryTypeSearchComponent } from './components/postHistoryType/postHistoryTypeSearchForm';
import { WrappedPostLinkCreateComponent } from './components/postLink/postLinkCreateForm';
import { WrappedPostLinkDetailComponent } from './components/postLink/postLinkDetailForm';
import { WrappedPostLinkEditComponent } from './components/postLink/postLinkEditForm';
import { WrappedPostLinkSearchComponent } from './components/postLink/postLinkSearchForm';
import { WrappedPostCreateComponent } from './components/post/postCreateForm';
import { WrappedPostDetailComponent } from './components/post/postDetailForm';
import { WrappedPostEditComponent } from './components/post/postEditForm';
import { WrappedPostSearchComponent } from './components/post/postSearchForm';
import { WrappedPostTypeCreateComponent } from './components/postType/postTypeCreateForm';
import { WrappedPostTypeDetailComponent } from './components/postType/postTypeDetailForm';
import { WrappedPostTypeEditComponent } from './components/postType/postTypeEditForm';
import { WrappedPostTypeSearchComponent } from './components/postType/postTypeSearchForm';
import { WrappedTagCreateComponent } from './components/tag/tagCreateForm';
import { WrappedTagDetailComponent } from './components/tag/tagDetailForm';
import { WrappedTagEditComponent } from './components/tag/tagEditForm';
import { WrappedTagSearchComponent } from './components/tag/tagSearchForm';
import { WrappedUserCreateComponent } from './components/user/userCreateForm';
import { WrappedUserDetailComponent } from './components/user/userDetailForm';
import { WrappedUserEditComponent } from './components/user/userEditForm';
import { WrappedUserSearchComponent } from './components/user/userSearchForm';
import { WrappedVoteCreateComponent } from './components/vote/voteCreateForm';
import { WrappedVoteDetailComponent } from './components/vote/voteDetailForm';
import { WrappedVoteEditComponent } from './components/vote/voteEditForm';
import { WrappedVoteSearchComponent } from './components/vote/voteSearchForm';
import { WrappedVoteTypeCreateComponent } from './components/voteType/voteTypeCreateForm';
import { WrappedVoteTypeDetailComponent } from './components/voteType/voteTypeDetailForm';
import { WrappedVoteTypeEditComponent } from './components/voteType/voteTypeEditForm';
import { WrappedVoteTypeSearchComponent } from './components/voteType/voteTypeSearchForm';

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
          path={ClientRoutes.Badges + '/create'}
          component={wrapperHeader(
            WrappedBadgeCreateComponent,
            'Badges Create'
          )}
        />
        <Route
          path={ClientRoutes.Badges + '/edit/:id'}
          component={wrapperHeader(WrappedBadgeEditComponent, 'Badges Edit')}
        />
        <Route
          path={ClientRoutes.Badges + '/:id'}
          component={wrapperHeader(
            WrappedBadgeDetailComponent,
            'Badges Detail'
          )}
        />
        <Route
          path={ClientRoutes.Badges}
          component={wrapperHeader(
            WrappedBadgeSearchComponent,
            'Badges Search'
          )}
        />
        <Route
          path={ClientRoutes.Comments + '/create'}
          component={wrapperHeader(
            WrappedCommentCreateComponent,
            'Comments Create'
          )}
        />
        <Route
          path={ClientRoutes.Comments + '/edit/:id'}
          component={wrapperHeader(
            WrappedCommentEditComponent,
            'Comments Edit'
          )}
        />
        <Route
          path={ClientRoutes.Comments + '/:id'}
          component={wrapperHeader(
            WrappedCommentDetailComponent,
            'Comments Detail'
          )}
        />
        <Route
          path={ClientRoutes.Comments}
          component={wrapperHeader(
            WrappedCommentSearchComponent,
            'Comments Search'
          )}
        />
        <Route
          path={ClientRoutes.LinkTypes + '/create'}
          component={wrapperHeader(
            WrappedLinkTypeCreateComponent,
            'Link Types Create'
          )}
        />
        <Route
          path={ClientRoutes.LinkTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedLinkTypeEditComponent,
            'Link Types Edit'
          )}
        />
        <Route
          path={ClientRoutes.LinkTypes + '/:id'}
          component={wrapperHeader(
            WrappedLinkTypeDetailComponent,
            'Link Types Detail'
          )}
        />
        <Route
          path={ClientRoutes.LinkTypes}
          component={wrapperHeader(
            WrappedLinkTypeSearchComponent,
            'Link Types Search'
          )}
        />
        <Route
          path={ClientRoutes.PostHistories + '/create'}
          component={wrapperHeader(
            WrappedPostHistoryCreateComponent,
            'Post History Create'
          )}
        />
        <Route
          path={ClientRoutes.PostHistories + '/edit/:id'}
          component={wrapperHeader(
            WrappedPostHistoryEditComponent,
            'Post History Edit'
          )}
        />
        <Route
          path={ClientRoutes.PostHistories + '/:id'}
          component={wrapperHeader(
            WrappedPostHistoryDetailComponent,
            'Post History Detail'
          )}
        />
        <Route
          path={ClientRoutes.PostHistories}
          component={wrapperHeader(
            WrappedPostHistorySearchComponent,
            'Post History Search'
          )}
        />
        <Route
          path={ClientRoutes.PostHistoryTypes + '/create'}
          component={wrapperHeader(
            WrappedPostHistoryTypeCreateComponent,
            'Post History Types Create'
          )}
        />
        <Route
          path={ClientRoutes.PostHistoryTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedPostHistoryTypeEditComponent,
            'Post History Types Edit'
          )}
        />
        <Route
          path={ClientRoutes.PostHistoryTypes + '/:id'}
          component={wrapperHeader(
            WrappedPostHistoryTypeDetailComponent,
            'Post History Types Detail'
          )}
        />
        <Route
          path={ClientRoutes.PostHistoryTypes}
          component={wrapperHeader(
            WrappedPostHistoryTypeSearchComponent,
            'Post History Types Search'
          )}
        />
        <Route
          path={ClientRoutes.PostLinks + '/create'}
          component={wrapperHeader(
            WrappedPostLinkCreateComponent,
            'Post Links Create'
          )}
        />
        <Route
          path={ClientRoutes.PostLinks + '/edit/:id'}
          component={wrapperHeader(
            WrappedPostLinkEditComponent,
            'Post Links Edit'
          )}
        />
        <Route
          path={ClientRoutes.PostLinks + '/:id'}
          component={wrapperHeader(
            WrappedPostLinkDetailComponent,
            'Post Links Detail'
          )}
        />
        <Route
          path={ClientRoutes.PostLinks}
          component={wrapperHeader(
            WrappedPostLinkSearchComponent,
            'Post Links Search'
          )}
        />
        <Route
          path={ClientRoutes.Posts + '/create'}
          component={wrapperHeader(WrappedPostCreateComponent, 'Posts Create')}
        />
        <Route
          path={ClientRoutes.Posts + '/edit/:id'}
          component={wrapperHeader(WrappedPostEditComponent, 'Posts Edit')}
        />
        <Route
          path={ClientRoutes.Posts + '/:id'}
          component={wrapperHeader(WrappedPostDetailComponent, 'Posts Detail')}
        />
        <Route
          path={ClientRoutes.Posts}
          component={wrapperHeader(WrappedPostSearchComponent, 'Posts Search')}
        />
        <Route
          path={ClientRoutes.PostTypes + '/create'}
          component={wrapperHeader(
            WrappedPostTypeCreateComponent,
            'Post Types Create'
          )}
        />
        <Route
          path={ClientRoutes.PostTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedPostTypeEditComponent,
            'Post Types Edit'
          )}
        />
        <Route
          path={ClientRoutes.PostTypes + '/:id'}
          component={wrapperHeader(
            WrappedPostTypeDetailComponent,
            'Post Types Detail'
          )}
        />
        <Route
          path={ClientRoutes.PostTypes}
          component={wrapperHeader(
            WrappedPostTypeSearchComponent,
            'Post Types Search'
          )}
        />
        <Route
          path={ClientRoutes.Tags + '/create'}
          component={wrapperHeader(WrappedTagCreateComponent, 'Tags Create')}
        />
        <Route
          path={ClientRoutes.Tags + '/edit/:id'}
          component={wrapperHeader(WrappedTagEditComponent, 'Tags Edit')}
        />
        <Route
          path={ClientRoutes.Tags + '/:id'}
          component={wrapperHeader(WrappedTagDetailComponent, 'Tags Detail')}
        />
        <Route
          path={ClientRoutes.Tags}
          component={wrapperHeader(WrappedTagSearchComponent, 'Tags Search')}
        />
        <Route
          path={ClientRoutes.Users + '/create'}
          component={wrapperHeader(WrappedUserCreateComponent, 'Users Create')}
        />
        <Route
          path={ClientRoutes.Users + '/edit/:id'}
          component={wrapperHeader(WrappedUserEditComponent, 'Users Edit')}
        />
        <Route
          path={ClientRoutes.Users + '/:id'}
          component={wrapperHeader(WrappedUserDetailComponent, 'Users Detail')}
        />
        <Route
          path={ClientRoutes.Users}
          component={wrapperHeader(WrappedUserSearchComponent, 'Users Search')}
        />
        <Route
          path={ClientRoutes.Votes + '/create'}
          component={wrapperHeader(WrappedVoteCreateComponent, 'Votes Create')}
        />
        <Route
          path={ClientRoutes.Votes + '/edit/:id'}
          component={wrapperHeader(WrappedVoteEditComponent, 'Votes Edit')}
        />
        <Route
          path={ClientRoutes.Votes + '/:id'}
          component={wrapperHeader(WrappedVoteDetailComponent, 'Votes Detail')}
        />
        <Route
          path={ClientRoutes.Votes}
          component={wrapperHeader(WrappedVoteSearchComponent, 'Votes Search')}
        />
        <Route
          path={ClientRoutes.VoteTypes + '/create'}
          component={wrapperHeader(
            WrappedVoteTypeCreateComponent,
            'Vote Types Create'
          )}
        />
        <Route
          path={ClientRoutes.VoteTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedVoteTypeEditComponent,
            'Vote Types Edit'
          )}
        />
        <Route
          path={ClientRoutes.VoteTypes + '/:id'}
          component={wrapperHeader(
            WrappedVoteTypeDetailComponent,
            'Vote Types Detail'
          )}
        />
        <Route
          path={ClientRoutes.VoteTypes}
          component={wrapperHeader(
            WrappedVoteTypeSearchComponent,
            'Vote Types Search'
          )}
        />
        <Route render={() => <div>No handler for route found...</div>} />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>14e8c6409c0c71084a8bf5d5256d1141</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/