import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import ReplyMapper from './replyMapper';
import ReplyViewModel from './replyViewModel';

interface Props {
  history: any;
  model?: ReplyViewModel;
}

const ReplyDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.Replies + '/edit/' + model.model!.replyId
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
        <label htmlFor="replierUserId" className={'col-sm-2 col-form-label'}>
          Replier_user_id
        </label>
        <div className="col-sm-12">
          {model.model!.replierUserIdNavigation!.toDisplay()}
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
  replyId: number;
}

interface IMatch {
  params: IParams;
}

interface ReplyDetailComponentProps {
  match: IMatch;
  history: any;
}

interface ReplyDetailComponentState {
  model?: ReplyViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class ReplyDetailComponent extends React.Component<
  ReplyDetailComponentProps,
  ReplyDetailComponentState
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
          ApiRoutes.Replies +
          '/' +
          this.props.match.params.replyId,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.ReplyClientResponseModel;

          let mapper = new ReplyMapper();

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
        <ReplyDetailDisplay
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
    <Hash>9fb6a8244f395e0f6e930cabb30834e6</Hash>
</Codenesium>*/