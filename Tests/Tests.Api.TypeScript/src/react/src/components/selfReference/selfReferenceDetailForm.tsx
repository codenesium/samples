import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import SelfReferenceMapper from './selfReferenceMapper';
import SelfReferenceViewModel from './selfReferenceViewModel';

interface Props {
  history: any;
  model?: SelfReferenceViewModel;
}

const SelfReferenceDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.SelfReferences + '/edit/' + model.model!.id
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="selfReferenceId" className={'col-sm-2 col-form-label'}>
          SelfReferenceId
        </label>
        <div className="col-sm-12">
          {model.model!.selfReferenceIdNavigation!.toDisplay()}
        </div>
      </div>
      <div className="form-group row">
        <label htmlFor="selfReferenceId2" className={'col-sm-2 col-form-label'}>
          SelfReferenceId2
        </label>
        <div className="col-sm-12">
          {model.model!.selfReferenceId2Navigation!.toDisplay()}
        </div>
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

interface SelfReferenceDetailComponentProps {
  match: IMatch;
  history: any;
}

interface SelfReferenceDetailComponentState {
  model?: SelfReferenceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class SelfReferenceDetailComponent extends React.Component<
  SelfReferenceDetailComponentProps,
  SelfReferenceDetailComponentState
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
          ApiRoutes.SelfReferences +
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
          let response = resp.data as Api.SelfReferenceClientResponseModel;

          let mapper = new SelfReferenceMapper();

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
        <SelfReferenceDetailDisplay
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
    <Hash>54e62a6603fdd5f7be5e4fb9107120fb</Hash>
</Codenesium>*/