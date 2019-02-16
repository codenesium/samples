import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import EmployeeMapper from './employeeMapper';
import EmployeeViewModel from './employeeViewModel';

interface Props {
  history: any;
  model?: EmployeeViewModel;
}

const EmployeeDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.Employees + '/edit/' + model.model!.id
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="firstName" className={'col-sm-2 col-form-label'}>
          FirstName
        </label>
        <div className="col-sm-12">{String(model.model!.firstName)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="id" className={'col-sm-2 col-form-label'}>
          Id
        </label>
        <div className="col-sm-12">{String(model.model!.id)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="isSalesPerson" className={'col-sm-2 col-form-label'}>
          IsSalesPerson
        </label>
        <div className="col-sm-12">{String(model.model!.isSalesPerson)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="isShipper" className={'col-sm-2 col-form-label'}>
          IsShipper
        </label>
        <div className="col-sm-12">{String(model.model!.isShipper)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="lastName" className={'col-sm-2 col-form-label'}>
          LastName
        </label>
        <div className="col-sm-12">{String(model.model!.lastName)}</div>
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

interface EmployeeDetailComponentProps {
  match: IMatch;
  history: any;
}

interface EmployeeDetailComponentState {
  model?: EmployeeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class EmployeeDetailComponent extends React.Component<
  EmployeeDetailComponentProps,
  EmployeeDetailComponentState
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
          ApiRoutes.Employees +
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
          let response = resp.data as Api.EmployeeClientResponseModel;

          let mapper = new EmployeeMapper();

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
        <EmployeeDetailDisplay
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
    <Hash>8b8703bb9034b88432263e1573304420</Hash>
</Codenesium>*/