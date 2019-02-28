import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import EmployeeMapper from './employeeMapper';
import EmployeeViewModel from './employeeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { EmployeeDepartmentHistoryTableComponent } from '../shared/employeeDepartmentHistoryTable';
import { EmployeePayHistoryTableComponent } from '../shared/employeePayHistoryTable';
import { JobCandidateTableComponent } from '../shared/jobCandidateTable';

interface EmployeeDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface EmployeeDetailComponentState {
  model?: EmployeeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class EmployeeDetailComponent extends React.Component<
  EmployeeDetailComponentProps,
  EmployeeDetailComponentState
> {
  state = {
    model: new EmployeeViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Employees + '/edit/' + this.state.model!.businessEntityID
    );
  }

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

          console.log(response);

          let mapper = new EmployeeMapper();

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
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>BirthDate</h3>
              <p>{String(this.state.model!.birthDate)}</p>
            </div>
            <div>
              <h3>BusinessEntityID</h3>
              <p>{String(this.state.model!.businessEntityID)}</p>
            </div>
            <div>
              <h3>CurrentFlag</h3>
              <p>{String(this.state.model!.currentFlag)}</p>
            </div>
            <div>
              <h3>Gender</h3>
              <p>{String(this.state.model!.gender)}</p>
            </div>
            <div>
              <h3>HireDate</h3>
              <p>{String(this.state.model!.hireDate)}</p>
            </div>
            <div>
              <h3>JobTitle</h3>
              <p>{String(this.state.model!.jobTitle)}</p>
            </div>
            <div>
              <h3>LoginID</h3>
              <p>{String(this.state.model!.loginID)}</p>
            </div>
            <div>
              <h3>MaritalStatus</h3>
              <p>{String(this.state.model!.maritalStatu)}</p>
            </div>
            <div>
              <h3>ModifiedDate</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>NationalIDNumber</h3>
              <p>{String(this.state.model!.nationalIDNumber)}</p>
            </div>
            <div>
              <h3>OrganizationLevel</h3>
              <p>{String(this.state.model!.organizationLevel)}</p>
            </div>
            <div>
              <h3>rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>SalariedFlag</h3>
              <p>{String(this.state.model!.salariedFlag)}</p>
            </div>
            <div>
              <h3>SickLeaveHours</h3>
              <p>{String(this.state.model!.sickLeaveHour)}</p>
            </div>
            <div>
              <h3>VacationHours</h3>
              <p>{String(this.state.model!.vacationHour)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>EmployeeDepartmentHistories</h3>
            <EmployeeDepartmentHistoryTableComponent
              businessEntityID={this.state.model!.businessEntityID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Employees +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.EmployeeDepartmentHistories
              }
            />
          </div>
          <div>
            <h3>EmployeePayHistories</h3>
            <EmployeePayHistoryTableComponent
              businessEntityID={this.state.model!.businessEntityID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Employees +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.EmployeePayHistories
              }
            />
          </div>
          <div>
            <h3>JobCandidates</h3>
            <JobCandidateTableComponent
              jobCandidateID={this.state.model!.jobCandidateID}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Employees +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.JobCandidates
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedEmployeeDetailComponent = Form.create({
  name: 'Employee Detail',
})(EmployeeDetailComponent);


/*<Codenesium>
    <Hash>7a7a0cb4c2ac212f83b3d218b003bb05</Hash>
</Codenesium>*/