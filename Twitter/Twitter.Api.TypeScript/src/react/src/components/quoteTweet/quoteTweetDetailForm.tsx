import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import QuoteTweetMapper from './quoteTweetMapper';
import QuoteTweetViewModel from './quoteTweetViewModel';

interface Props {
  history: any;
  model?: QuoteTweetViewModel;
}

const QuoteTweetDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.QuoteTweets + '/edit/' + model.model!.quoteTweetId
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
        <label htmlFor="retweeterUserId" className={'col-sm-2 col-form-label'}>
          Retweeter_user_id
        </label>
        <div className="col-sm-12">
          {model.model!.retweeterUserIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="sourceTweetId" className={'col-sm-2 col-form-label'}>
          Source_tweet_id
        </label>
        <div className="col-sm-12">
          {model.model!.sourceTweetIdNavigation!.toDisplay()}
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
  quoteTweetId: number;
}

interface IMatch {
  params: IParams;
}

interface QuoteTweetDetailComponentProps {
  match: IMatch;
  history: any;
}

interface QuoteTweetDetailComponentState {
  model?: QuoteTweetViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class QuoteTweetDetailComponent extends React.Component<
  QuoteTweetDetailComponentProps,
  QuoteTweetDetailComponentState
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
          ApiRoutes.QuoteTweets +
          '/' +
          this.props.match.params.quoteTweetId,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.QuoteTweetClientResponseModel;

          let mapper = new QuoteTweetMapper();

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
        <QuoteTweetDetailDisplay
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
    <Hash>7c191f20f444cbcd91488b642faed5c3</Hash>
</Codenesium>*/