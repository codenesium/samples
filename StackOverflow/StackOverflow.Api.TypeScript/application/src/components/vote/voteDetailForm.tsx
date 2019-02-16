import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import VoteMapper from './voteMapper';
import VoteViewModel from './voteViewModel';

interface Props {
  history: any;
  model?: VoteViewModel;
}

const VoteDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(ClientRoutes.Votes + '/edit/' + model.model!.id);
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="bountyAmount" className={'col-sm-2 col-form-label'}>
          BountyAmount
        </label>
        <div className="col-sm-12">{String(model.model!.bountyAmount)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="creationDate" className={'col-sm-2 col-form-label'}>
          CreationDate
        </label>
        <div className="col-sm-12">{String(model.model!.creationDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="postId" className={'col-sm-2 col-form-label'}>
          PostId
        </label>
        <div className="col-sm-12">{String(model.model!.postId)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="userId" className={'col-sm-2 col-form-label'}>
          UserId
        </label>
        <div className="col-sm-12">{String(model.model!.userId)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="voteTypeId" className={'col-sm-2 col-form-label'}>
          VoteTypeId
        </label>
        <div className="col-sm-12">{String(model.model!.voteTypeId)}</div>
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

interface VoteDetailComponentProps {
  match: IMatch;
  history: any;
}

interface VoteDetailComponentState {
  model?: VoteViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class VoteDetailComponent extends React.Component<
  VoteDetailComponentProps,
  VoteDetailComponentState
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
          ApiRoutes.Votes +
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
          let response = resp.data as Api.VoteClientResponseModel;

          let mapper = new VoteMapper();

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
        <VoteDetailDisplay
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
    <Hash>475f8aad7c59405b05d283282785ea65</Hash>
</Codenesium>*/