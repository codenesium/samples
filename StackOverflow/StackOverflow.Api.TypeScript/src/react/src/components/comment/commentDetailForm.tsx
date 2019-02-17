import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import CommentMapper from './commentMapper';
import CommentViewModel from './commentViewModel';

interface Props {
  history: any;
  model?: CommentViewModel;
}

const CommentDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.Comments + '/edit/' + model.model!.id
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="creationDate" className={'col-sm-2 col-form-label'}>
          CreationDate
        </label>
        <div className="col-sm-12">{String(model.model!.creationDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="postId" className={'col-sm-2 col-form-label'}>
          PostId
        </label>
        <div className="col-sm-12">{String(model.model!.postId)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="score" className={'col-sm-2 col-form-label'}>
          Score
        </label>
        <div className="col-sm-12">{String(model.model!.score)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="text" className={'col-sm-2 col-form-label'}>
          Text
        </label>
        <div className="col-sm-12">{String(model.model!.text)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="userId" className={'col-sm-2 col-form-label'}>
          UserId
        </label>
        <div className="col-sm-12">{String(model.model!.userId)}</div>
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

interface CommentDetailComponentProps {
  match: IMatch;
  history: any;
}

interface CommentDetailComponentState {
  model?: CommentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class CommentDetailComponent extends React.Component<
  CommentDetailComponentProps,
  CommentDetailComponentState
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
          ApiRoutes.Comments +
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
          let response = resp.data as Api.CommentClientResponseModel;

          let mapper = new CommentMapper();

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
        <CommentDetailDisplay
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
    <Hash>a7933ef48f19b464bdd8d0bbbe48a195</Hash>
</Codenesium>*/