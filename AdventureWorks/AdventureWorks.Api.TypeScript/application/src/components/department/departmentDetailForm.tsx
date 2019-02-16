import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import DepartmentMapper from './departmentMapper';
import DepartmentViewModel from './departmentViewModel';

interface Props {
  model?: DepartmentViewModel;
}

const DepartmentDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="departmentID" className={'col-sm-2 col-form-label'}>
          DepartmentID
        </label>
        <div className="col-sm-12">{String(model.model!.departmentID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="groupName" className={'col-sm-2 col-form-label'}>
          GroupName
        </label>
        <div className="col-sm-12">{String(model.model!.groupName)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="name" className={'col-sm-2 col-form-label'}>
          Name
        </label>
        <div className="col-sm-12">{String(model.model!.name)}</div>
      </div>
    </form>
  );
};

interface IParams {
  departmentID: number;
}

interface IMatch {
  params: IParams;
}

interface DepartmentDetailComponentProps {
  match: IMatch;
}

interface DepartmentDetailComponentState {
  model?: DepartmentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class DepartmentDetailComponent extends React.Component<
  DepartmentDetailComponentProps,
  DepartmentDetailComponentState
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
        Constants.ApiUrl +
          'departments/' +
          this.props.match.params.departmentID,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.DepartmentClientResponseModel;

          let mapper = new DepartmentMapper();

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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <DepartmentDetailDisplay model={this.state.model} />;
    } else if (this.state.errorOccurred) {
      return (
        <div className="alert alert-danger">{this.state.errorMessage}</div>
      );
    } else {
      return <div />;
    }
  }
}


/*<Codenesium>
    <Hash>a002896f7bad40102abde88b5b050398</Hash>
</Codenesium>*/