import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import IncludedColumnTestMapper from './includedColumnTestMapper';
import IncludedColumnTestViewModel from './includedColumnTestViewModel';

interface Props {
  history: any;
  model?: IncludedColumnTestViewModel;
}

const IncludedColumnTestDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.IncludedColumnTests + '/edit/' + model.model!.id
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
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{String(model.model!.name)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="name2" className={'col-sm-2 col-form-label'}>
          Name2
        </label>
        <div className="col-sm-12">{String(model.model!.name2)}</div>
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

interface IncludedColumnTestDetailComponentProps {
  match: IMatch;
  history: any;
}

interface IncludedColumnTestDetailComponentState {
  model?: IncludedColumnTestViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class IncludedColumnTestDetailComponent extends React.Component<
  IncludedColumnTestDetailComponentProps,
  IncludedColumnTestDetailComponentState
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
          ApiRoutes.IncludedColumnTests +
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
          let response = resp.data as Api.IncludedColumnTestClientResponseModel;

          let mapper = new IncludedColumnTestMapper();

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
        <IncludedColumnTestDetailDisplay
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
    <Hash>37b11c1ad2fa6de5b0c17279d375de71</Hash>
</Codenesium>*/