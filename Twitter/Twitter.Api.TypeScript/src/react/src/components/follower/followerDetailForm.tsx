import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import FollowerMapper from './followerMapper';
import FollowerViewModel from './followerViewModel';

interface Props {
  history: any;
  model?: FollowerViewModel;
}

const FollowerDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.Followers + '/edit/' + model.model!.id
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="blocked" className={'col-sm-2 col-form-label'}>
          Blocked
        </label>
        <div className="col-sm-12">{String(model.model!.blocked)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="dateFollowed" className={'col-sm-2 col-form-label'}>
          Date_followed
        </label>
        <div className="col-sm-12">{String(model.model!.dateFollowed)}</div>
      </div>
      <div className="form-group row">
        <label
          htmlFor="followRequestStatu"
          className={'col-sm-2 col-form-label'}
        >
          Follow_request_status
        </label>
        <div className="col-sm-12">
          {String(model.model!.followRequestStatu)}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="followedUserId" className={'col-sm-2 col-form-label'}>
          Followed_user_id
        </label>
        <div className="col-sm-12">
          {model.model!.followedUserIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="followingUserId" className={'col-sm-2 col-form-label'}>
          Following_user_id
        </label>
        <div className="col-sm-12">
          {model.model!.followingUserIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="muted" className={'col-sm-2 col-form-label'}>
          Muted
        </label>
        <div className="col-sm-12">{String(model.model!.muted)}</div>
      </div>
    </form>
  );
};

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface FollowerDetailComponentProps {
  match: IMatch;
  history: any;
}

interface FollowerDetailComponentState {
  model?: FollowerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class FollowerDetailComponent extends React.Component<
  FollowerDetailComponentProps,
  FollowerDetailComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Followers +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.FollowerClientResponseModel;

          let mapper = new FollowerMapper();

          console.log(response);

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }
  render() {
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return (
        <FollowerDetailDisplay
          history={this.props.history}
          model={this.state.model}
        />
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>cd0937e9204c9a787025121ab247fed8</Hash>
</Codenesium>*/