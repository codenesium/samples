import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import DirectTweetMapper from './directTweetMapper';
import DirectTweetViewModel from './directTweetViewModel';

interface Props {
  history: any;
  model?: DirectTweetViewModel;
}

const DirectTweetDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.DirectTweets + '/edit/' + model.model!.tweetId
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="content" className={'col-sm-2 col-form-label'}>
          Content
        </label>
        <div className="col-sm-12">{String(model.model!.content)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="date" className={'col-sm-2 col-form-label'}>
          Date
        </label>
        <div className="col-sm-12">{String(model.model!.date)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="taggedUserId" className={'col-sm-2 col-form-label'}>
          Tagged_user_id
        </label>
        <div className="col-sm-12">
          {model.model!.taggedUserIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="time" className={'col-sm-2 col-form-label'}>
          Time
        </label>
        <div className="col-sm-12">{String(model.model!.time)}</div>
      </div>
    </form>
  );
};

interface IParams {
  tweetId: number;
}

interface IMatch {
  params: IParams;
}

interface DirectTweetDetailComponentProps {
  match: IMatch;
  history: any;
}

interface DirectTweetDetailComponentState {
  model?: DirectTweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class DirectTweetDetailComponent extends React.Component<
  DirectTweetDetailComponentProps,
  DirectTweetDetailComponentState
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
          ApiRoutes.DirectTweets +
          '/' +
          this.props.match.params.tweetId,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.DirectTweetClientResponseModel;

          let mapper = new DirectTweetMapper();

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
        <DirectTweetDetailDisplay
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
    <Hash>2c8ff18a7cc4e98f27a1c14ec51c5cf6</Hash>
</Codenesium>*/