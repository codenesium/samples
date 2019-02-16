import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects';
import Constants from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import EmployeeMapper from './employeeMapper';
import EmployeeViewModel from './employeeViewModel';

interface Props {
  model?: EmployeeViewModel;
}

const EmployeeDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <div className="form-group row">
        <label htmlFor="birthDate" className={'col-sm-2 col-form-label'}>
          BirthDate
        </label>
        <div className="col-sm-12">{String(model.model!.birthDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="businessEntityID" className={'col-sm-2 col-form-label'}>
          BusinessEntityID
        </label>
        <div className="col-sm-12">{String(model.model!.businessEntityID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="currentFlag" className={'col-sm-2 col-form-label'}>
          CurrentFlag
        </label>
        <div className="col-sm-12">{String(model.model!.currentFlag)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="gender" className={'col-sm-2 col-form-label'}>
          Gender
        </label>
        <div className="col-sm-12">{String(model.model!.gender)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="hireDate" className={'col-sm-2 col-form-label'}>
          HireDate
        </label>
        <div className="col-sm-12">{String(model.model!.hireDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="jobTitle" className={'col-sm-2 col-form-label'}>
          JobTitle
        </label>
        <div className="col-sm-12">{String(model.model!.jobTitle)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="loginID" className={'col-sm-2 col-form-label'}>
          LoginID
        </label>
        <div className="col-sm-12">{String(model.model!.loginID)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="maritalStatu" className={'col-sm-2 col-form-label'}>
          MaritalStatus
        </label>
        <div className="col-sm-12">{String(model.model!.maritalStatu)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="modifiedDate" className={'col-sm-2 col-form-label'}>
          ModifiedDate
        </label>
        <div className="col-sm-12">{String(model.model!.modifiedDate)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="nationalIDNumber" className={'col-sm-2 col-form-label'}>
          NationalIDNumber
        </label>
        <div className="col-sm-12">{String(model.model!.nationalIDNumber)}</div>
      </div>

      <div className="form-group row">
        <label
          htmlFor="organizationLevel"
          className={'col-sm-2 col-form-label'}
        >
          OrganizationLevel
        </label>
        <div className="col-sm-12">
          {String(model.model!.organizationLevel)}
        </div>
      </div>

      <div className="form-group row">
        <label htmlFor="rowguid" className={'col-sm-2 col-form-label'}>
          Rowguid
        </label>
        <div className="col-sm-12">{String(model.model!.rowguid)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="salariedFlag" className={'col-sm-2 col-form-label'}>
          SalariedFlag
        </label>
        <div className="col-sm-12">{String(model.model!.salariedFlag)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="sickLeaveHour" className={'col-sm-2 col-form-label'}>
          SickLeaveHours
        </label>
        <div className="col-sm-12">{String(model.model!.sickLeaveHour)}</div>
      </div>

      <div className="form-group row">
        <label htmlFor="vacationHour" className={'col-sm-2 col-form-label'}>
          VacationHours
        </label>
        <div className="col-sm-12">{String(model.model!.vacationHour)}</div>
      </div>
    </form>
  );
};

interface IParams {
  businessEntityID: number;
}

interface IMatch {
  params: IParams;
}

interface EmployeeDetailComponentProps {
  match: IMatch;
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
        Constants.ApiUrl +
          'employees/' +
          this.props.match.params.businessEntityID,
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
      return <div>loading</div>;
    } else if (this.state.loaded) {
      return <EmployeeDetailDisplay model={this.state.model} />;
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
    <Hash>915318ef25d854c000bacd25a62a527d</Hash>
</Codenesium>*/